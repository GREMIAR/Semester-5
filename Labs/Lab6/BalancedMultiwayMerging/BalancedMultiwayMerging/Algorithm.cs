using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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

        int InitialDistribution()
        {
            originalFile = File.Open(filename, FileMode.Open); // для чтения
            for (int i = 0; i < mergeWaysCount; i++)
            {
                workFile[i] = File.Open(workPath + "\\workFile" + i.ToString() + ".txt", FileMode.Open); // для записи
            }
            int nextOutputFileIndex = 0;
            int segmentCount = 0;
            while (!EndOfFile(originalFile))
            {
                originalFile.Read(buffer, 0, buffer.Length);
                workFile[nextOutputFileIndex].Write(buffer, 0, buffer.Length);
                workFile[nextOutputFileIndex].Write(separator, 0, separator.Length);
                nextOutputFileIndex = NextOutputFileIndex1N(nextOutputFileIndex);
                segmentCount++;
            }
            Close();
            return segmentCount;
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

        void OpenForMerge(int activeFilesCount, int[] indexMap)
        {
            for (int i = 0; i < activeFilesCount; i++)
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

        int FindFileWithMinSegment(int activeFilesWithActiveSegmentsCount, List<int> filesWithActiveSegmentsIndex)
        {
            int min = filesWithActiveSegmentsIndex[0];
            for (int i = 0; i < activeFilesWithActiveSegmentsCount - 1; i++)
            {
                Byte[] buffer1 = new byte[buffer.Length];
                Byte[] buffer2 = new byte[buffer.Length];
                int readByteLength1 = ReadNoSeekModification(ref workFile[min], ref buffer1, 0, buffer1.Length);
                int readByteLength2 = ReadNoSeekModification(ref workFile[filesWithActiveSegmentsIndex[i + 1]], ref buffer2, 0, buffer2.Length);
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

        List<int> InitializeActiveFileIndexArray(int activeFilesCount, int[] indexMap)
        {
            List<int> filesWithActiveSegmentsIndex = new List<int>();
            for (int i = 0; i < activeFilesCount; i++)
            {
                filesWithActiveSegmentsIndex.Add(indexMap[i]);
            }
            return filesWithActiveSegmentsIndex;
        }

        public void Sort()
        {
            CreateWorkDir();
            int segmentCount = InitialDistribution();
            int[] indexMap = InitializeIndexMap();


            while (segmentCount != 1)
            {
                int activeFilesCount = Math.Min(segmentCount, mergeWaysCount);
                OpenForMerge(activeFilesCount, indexMap);
                List<int> filesWithActiveSegmentsIndex = InitializeActiveFileIndexArray(activeFilesCount, indexMap);
                segmentCount = 0;
                int nextOutputFileIndex = mergeWaysCount;
                while(activeFilesCount!=0)
                {
                    segmentCount++;
                    MergeFirstActiveSegments(ref activeFilesCount, ref filesWithActiveSegmentsIndex, indexMap, nextOutputFileIndex);
                    nextOutputFileIndex = NextOutputFileIndex2N(nextOutputFileIndex);
                }
                indexMap = SwitchIndexMap(indexMap);
                Close();
            }
            Finish(indexMap);
        }

        void MergeFirstActiveSegments(ref int activeFilesCount, ref List<int> filesWithActiveSegmentsIndex, int[] indexMap, int nextOutputFileIndex)
        {
            int activeFilesWithActiveSegmentsCount = activeFilesCount;
            while (activeFilesWithActiveSegmentsCount != 0)
            {
                int IndexOfAFileWithMinSegment = FindFileWithMinSegment(activeFilesWithActiveSegmentsCount, filesWithActiveSegmentsIndex);
                workFile[filesWithActiveSegmentsIndex[IndexOfAFileWithMinSegment]].Read(buffer, 0, buffer.Length);
                workFile[indexMap[nextOutputFileIndex]].Write(buffer, 0, buffer.Length);
                if (EndOfFile(workFile[filesWithActiveSegmentsIndex[IndexOfAFileWithMinSegment]]))
                {
                    FinishFile(ref activeFilesCount, ref activeFilesWithActiveSegmentsCount, ref filesWithActiveSegmentsIndex, IndexOfAFileWithMinSegment);
                }
                else if (EndOfSegment(workFile[filesWithActiveSegmentsIndex[IndexOfAFileWithMinSegment]]))
                {
                    FinishSegment(ref activeFilesWithActiveSegmentsCount, ref filesWithActiveSegmentsIndex, IndexOfAFileWithMinSegment, indexMap, nextOutputFileIndex);
                }
            }
        }

        void FinishFile(ref int activeFilesCount, ref int activeFilesWithActiveSegmentsCount, ref List<int> filesWithActiveSegmentsIndex, int IndexOfAFileWithMinSegment)
        {
            activeFilesCount = ModifyAF(activeFilesCount);
            activeFilesWithActiveSegmentsCount = ModifyAO(activeFilesWithActiveSegmentsCount);
            filesWithActiveSegmentsIndex = ModifyTA(filesWithActiveSegmentsIndex, IndexOfAFileWithMinSegment, mergeWaysCount - 1);
        }

        void FinishSegment(ref int activeFilesWithActiveSegmentsCount, ref List<int> filesWithActiveSegmentsIndex, int IndexOfAFileWithMinSegment, int[] indexMap, int nextOutputFileIndex)
        {
            workFile[filesWithActiveSegmentsIndex[IndexOfAFileWithMinSegment]].Read(new byte[separator.Length], 0, separator.Length);
            //workFile[indexMap[nextOutputFileIndex]].Write(separator, 0, separator.Length);
            activeFilesWithActiveSegmentsCount = ModifyAO(activeFilesWithActiveSegmentsCount);
            filesWithActiveSegmentsIndex = ModifyTA(filesWithActiveSegmentsIndex, IndexOfAFileWithMinSegment, activeFilesWithActiveSegmentsCount);
        }

        void Finish(int[] indexMap)
        {
            Close();
            string sortedDir = filePath + "\\BalancedMultiwayMerging_SORTED";
            Directory.CreateDirectory(sortedDir);
            File.Delete(sortedDir + "\\SORTED.txt");
            File.Copy(workPath + "\\workFile" + indexMap[0].ToString() + ".txt", sortedDir + "\\SORTED.txt");
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
            ReadNoSeekModification(ref fileStream, ref array, 0, array.Length);
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
            if (ReadNoSeekModification(ref fileStream, ref array, 0, array.Length) < separator.Length + 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        int ModifyAF(int activeFilesCount)
        {
            activeFilesCount--;
            return activeFilesCount;
        }

        int ModifyAO(int activeFilesWithActiveSegmentsCount)
        {
            activeFilesWithActiveSegmentsCount--;
            return activeFilesWithActiveSegmentsCount;
        }

        List<int> ModifyTA(List<int> filesWithActiveSegmentsIndex, int IndexOfAFileWithMinSegment, int insertPos)
        {
            int tmp = filesWithActiveSegmentsIndex[IndexOfAFileWithMinSegment];
            filesWithActiveSegmentsIndex.RemoveAt(IndexOfAFileWithMinSegment);
            filesWithActiveSegmentsIndex.Insert(insertPos, tmp);
            return filesWithActiveSegmentsIndex;
        }

        int ReadNoSeekModification(ref FileStream fileStream, ref Byte[] array, int offset, int count)
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

        int NextOutputFileIndex1N(int index)
        {
            index++;
            if (index >= mergeWaysCount)
            {
                index = 0;
            }
            return index;
        }

        int NextOutputFileIndex2N(int index)
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
