using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace BalancedMultiwayMerging
{
    class Algorithm
    {
        string filename;
        int mergeWaysCount;
        bool cleanRequired;
        string filePath;
        string workPath;
        FileStream originalFile;
        Byte[] buffer;
        FileStream[] workFile;
        readonly Byte[] separator = Encoding.UTF8.GetBytes("/");

        public Algorithm(string filename, int mergeWaysCount, bool cleanRequired)
        {
            this.filename = filename;
            this.mergeWaysCount = mergeWaysCount;
            this.cleanRequired = cleanRequired;
            this.filePath = filename.Substring(0, filename.LastIndexOf("\\"));
            this.workPath = filePath + "\\BalancedMultiwayMerging_Files";
            this.buffer = new byte[sizeof(int)];
            workFile = new FileStream[2*this.mergeWaysCount];
        }

        bool InitialDistribution(out int segmentCount)
        {
            segmentCount = 0;
            originalFile = File.Open(filename, FileMode.Open); // для чтения
            if(originalFile.Length>0)
            {
                for (int i = 0; i < mergeWaysCount; i++)
                {
                    workFile[i] = File.Open(workPath + "\\workFile" + i.ToString() + ".txt", FileMode.Open); // для записи
                }
                int nextOFIndex = 0;
                while (!EndOfFile(originalFile))
                {
                    originalFile.Read(buffer, 0, buffer.Length);
                    workFile[nextOFIndex].Write(buffer, 0, buffer.Length);
                    workFile[nextOFIndex].Write(separator, 0, separator.Length);
                    nextOFIndex = nextOFIndex1N(nextOFIndex);
                    segmentCount++;
                }
                Close();
                return true;
            }
            else
            {
                return false;
            }
        }

        void CreateWorkDir()
        {
            Directory.CreateDirectory(workPath);
            CreateWorkFiles();
        }

        void CreateWorkFiles()
        {
            for (int i = 0; i < 2 * mergeWaysCount; i++)
            {
                FileStream creating = File.Create(workPath + "\\workFile" + i.ToString() + ".txt");
                creating.Close();
            }
        }

        void OpenForMerge(int AFCount, int[] indexMap)
        {
            for (int i = 0; i < AFCount; i++)
            {
                workFile[indexMap[i]] = File.Open(workPath + "\\workFile" + (indexMap[i]).ToString() + ".txt", FileMode.Open);
            }
            for (int i = mergeWaysCount; i < 2 * mergeWaysCount; i++)
            {
                FileStream creating = File.Create(workPath + "\\workFile" + (indexMap[i]).ToString() + ".txt");
                creating.Close();
                workFile[indexMap[i]] = File.Open(workPath + "\\workFile" + (indexMap[i]).ToString() + ".txt", FileMode.Open);
            }
        }

        int FindMin(int AFWASCount, List<int> FWASIndexList)
        {
            int min = 0;
            for (int i = 0; i < AFWASCount - 1; i++)
            {
                Byte[] buffer1 = new byte[buffer.Length];
                Byte[] buffer2 = new byte[buffer.Length];
                int readByteLength1 = SafeRead(ref workFile[FWASIndexList[min]], ref buffer1, 0, buffer1.Length);
                int readByteLength2 = SafeRead(ref workFile[FWASIndexList[i + 1]], ref buffer2, 0, buffer2.Length);
                if (readByteLength1 != 0 && readByteLength2 != 0)
                {
                    int first = int.Parse(System.Text.Encoding.Default.GetString(buffer1).Substring(0, sizeof(int)));
                    int second = int.Parse(System.Text.Encoding.Default.GetString(buffer2).Substring(0, sizeof(int)));
                    if (second < first)
                    {
                        min = i + 1;
                    }
                }
            }
            return min;
        }

        List<int> InitializeAFWASIndexList(int AFCount, int[] indexMap)
        {
            List<int> FWASIndexList = new List<int>();
            for (int i = 0; i < AFCount; i++)
            {
                FWASIndexList.Add(indexMap[i]);
            }
            return FWASIndexList;
        }

        public void Sort()
        {
            CreateWorkDir();
            if(InitialDistribution(out int segmentCount))
            {
                int[] indexMap = InitializeIndexMap();
                while (segmentCount != 1)
                {
                    int AFCount = Math.Min(segmentCount, mergeWaysCount);
                    OpenForMerge(AFCount, indexMap);
                    List<int> FWASIndexList = InitializeAFWASIndexList(mergeWaysCount, indexMap);
                    segmentCount = 0;
                    int nextOFIndex = mergeWaysCount;
                    while(AFCount!=0)
                    {
                        segmentCount++;
                        Merge(ref AFCount, ref FWASIndexList, indexMap, nextOFIndex);
                        nextOFIndex = nextOFIndex2N(nextOFIndex);
                    }
                    indexMap = SwitchIndexMap(indexMap);
                    Close();
                }
                Finish(indexMap);
            }
            else
            {
                Clean();
                MessageBox.Show("Файл пустой");
            }
        }

        void Merge(ref int AFCount, ref List<int> FWASIndexList, int[] indexMap, int nextOFIndex)
        {
            int AFWASCount = AFCount;
            while (AFWASCount != 0)
            {
                int min = FindMin(AFWASCount, FWASIndexList);
                workFile[FWASIndexList[min]].Read(buffer, 0, buffer.Length);
                workFile[indexMap[nextOFIndex]].Write(buffer, 0, buffer.Length);
                if (EndOfFile(workFile[FWASIndexList[min]]))
                {
                    FinishFile(ref AFCount, ref AFWASCount, ref FWASIndexList, min);
                }
                else if (EndOfSegment(workFile[FWASIndexList[min]]))
                {
                    FinishSegment(ref AFWASCount, ref FWASIndexList, min, indexMap, nextOFIndex);
                }
            }
            workFile[indexMap[nextOFIndex]].Write(separator, 0, separator.Length);
        }

        void FinishFile(ref int AFCount, ref int AFWASCount, ref List<int> FWASIndexList, int min)
        {
            AFCount = ModifyAF(AFCount);
            AFWASCount = ModifyAO(AFWASCount);
            FWASIndexList = ModifyTA(FWASIndexList, min, mergeWaysCount - 1);
        }

        void FinishSegment(ref int AFWASCount, ref List<int> FWASIndexList, int min, int[] indexMap, int nextOFIndex)
        {
            workFile[FWASIndexList[min]].Read(new byte[separator.Length], 0, separator.Length);
            // workFile[indexMap[nextOFIndex]].Write(separator, 0, separator.Length);
            AFWASCount = ModifyAO(AFWASCount);
            FWASIndexList = ModifyTA(FWASIndexList, min, AFWASCount);
        }

        void Finish(int[] indexMap)
        {
            Close();
            string sortedDir = filePath + "\\BalancedMultiwayMerging_SORTED";
            Directory.CreateDirectory(sortedDir);
            FileStream file = File.Open(workPath + "\\workFile" + indexMap[0].ToString() + ".txt", FileMode.Open);
            if(file.Length>0)
            {
                file.SetLength(file.Length-1);
            }
            file.Close();
            File.Copy(workPath + "\\workFile" + indexMap[0].ToString() + ".txt", sortedDir + "\\SORTED.txt",true);
            Clean();
        }

        int[] InitializeIndexMap()
        {
            int[] indexMap = new int[2 * mergeWaysCount];
            for (int i = 0; i < 2 * mergeWaysCount; i++)
            {
                indexMap[i] = i;
            }
            return indexMap;
        }

        bool EndOfSegment(FileStream fileStream)
        {
            Byte[] array = new byte[separator.Length];
            SafeRead(ref fileStream, ref array, 0, array.Length);
            if (array[0] == separator[0])
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        bool EndOfFile(FileStream fileStream)
        {
            Byte[] array = new byte[separator.Length + 1];
            if (SafeRead(ref fileStream, ref array, 0, array.Length) < separator.Length + 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        int ModifyAF(int AFCount)
        {
            AFCount--;
            return AFCount;
        }

        int ModifyAO(int AFWASCount)
        {
            AFWASCount--;
            return AFWASCount;
        }

        List<int> ModifyTA(List<int> FWASIndexList, int min, int insertPos)
        {
            int tmp = FWASIndexList[min];
            FWASIndexList.RemoveAt(min);
            FWASIndexList.Insert(insertPos, tmp);
            return FWASIndexList;
        }

        int SafeRead(ref FileStream fileStream, ref Byte[] array, int offset, int count)
        {
            long pos = fileStream.Position;
            int readByteLength = fileStream.Read(array, 0, array.Length);
            fileStream.Seek(pos, SeekOrigin.Begin);
            return readByteLength;
        }

        int[] SwitchIndexMap(int[] indexMap)
        {
            int mergeWaysCount = indexMap.Length/2;
            int[] newIndexMap = new int[2*mergeWaysCount];
            for (int i = 0; i < mergeWaysCount; i++)
            {
                newIndexMap[i] = indexMap[i + mergeWaysCount];
                newIndexMap[i + mergeWaysCount] = indexMap[i];
            }
            return newIndexMap;
        }

        int nextOFIndex1N(int index)
        {
            index++;
            if (index >= mergeWaysCount)
            {
                index = 0;
            }
            return index;
        }

        int nextOFIndex2N(int index)
        {
            index++;
            if (index >= 2 * mergeWaysCount)
            {
                index = mergeWaysCount;
            }
            return index;
        }

        void Close()
        {
            if (originalFile != null)
            {
                originalFile.Close();
            }
            for(int i = 0; i < workFile.Length; i++)
            {
                if (workFile[i] != null)
                {
                    workFile[i].Close();
                }
            }
        }

        void Clean()
        {
            if (cleanRequired)
            {
                Directory.Delete(workPath, true);
            }
        }
    }
}
