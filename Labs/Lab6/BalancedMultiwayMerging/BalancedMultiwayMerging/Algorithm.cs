using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancedMultiwayMerging
{
    class Algorithm
    {
        string filename;
        int N;
        bool cleanRequired;
        string filePath;
        string workPath;
        FileStream f0;
        Byte[] buffer;
        FileStream[] f;

        public Algorithm(string filename, int mergeWays, bool cleanRequired)
        {
            this.filename = filename;
            this.N = mergeWays;
            this.cleanRequired = cleanRequired;
            this.filePath = filename.Substring(0, filename.LastIndexOf("\\"));
            this.workPath = filePath + "\\BalancedMultiwayMerging_Files";
            this.buffer = new byte[sizeof(int)];
            f = new FileStream[2*N];
        }

        void InitialDistribution(ref int j, ref int L)
        {
            f0 = File.Open(filename, FileMode.Open); // для чтения
            for (int i = 0; i < N; i++)
            {
                f[i] = File.Open(workPath + "\\f" + i.ToString() + ".txt", FileMode.Open); // для записи
            }
            j = 0;
            L = 0;
            while (!EndOfFile(f0))
            {
                f0.Read(buffer, 0, buffer.Length);
                f[j].Write(buffer, 0, buffer.Length);
                j++;
                if (j >= N)
                {
                    j = 0;
                }
                L++;
            }
            for (int i = 0; i < N; i++)
            {
                f[i].Close();
            }
        }

        void CreateWorkDir()
        {
            Directory.CreateDirectory(workPath);
            CreateWorkFiles();
        }

        void CreateWorkFiles()
        {
            for (int i = 0; i < 2 * N; i++)
            {
                FileStream creating = File.Create(workPath + "\\f" + i.ToString() + ".txt");
                creating.Close();
            }
        }

        void OpenForMerge(int af, int[] t)
        {
            for (int i = 0; i < af; i++)
            {
                f[t[i]] = File.Open(workPath + "\\f" + (t[i]).ToString() + ".txt", FileMode.Open); // для чтения
            }
            for (int i = N; i < 2 * N; i++)
            {
                f[t[i]] = File.Open(workPath + "\\f" + (t[i]).ToString() + ".txt", FileMode.Open); // для записи
            }
        }

        int FindFileWithMinSegment(int ao, List<int> ta)
        {
            int m = 0;
            for (int i = 0; i < ao - 1; i++)
            {
                Byte[] buffer1 = new byte[buffer.Length];
                Byte[] buffer2 = new byte[buffer.Length];
                int readByteLength1 = ReadNoSeekModification(ref f[ta[i]], ref buffer1, 0, buffer1.Length);
                int readByteLength2 = ReadNoSeekModification(ref f[ta[i + 1]], ref buffer2, 0, buffer2.Length);
                if (readByteLength1 != 0 && readByteLength2 != 0)
                {
                    int first = int.Parse(System.Text.Encoding.Default.GetString(buffer1).Substring(0, sizeof(int)));
                    int second = int.Parse(System.Text.Encoding.Default.GetString(buffer2).Substring(0, sizeof(int)));
                    if (second < first)
                    {
                        m = i + 1;
                    }
                }
            }
            return m;
        }

        List<int> InitializeActiveFileIndexArray(int af)
        {
            List<int> ta = new List<int>();
            for (int i = 0; i < af; i++)
            {
                ta.Add(i);
            }
            return ta;
        }

        public void Sort()
        {
            CreateWorkDir();
            int L = 0, j = 0;
            InitialDistribution(ref j, ref L);
            int[] t = InitializeIndexMap();

            while (L != 1)
            {
                int af = Math.Min(L, N);
                OpenForMerge(af, t);
                List<int> ta = InitializeActiveFileIndexArray(af);
                L = 0;
                j = N;
                while(af!=0)
                {
                    L++;
                    int ao = af;
                    int m;
                    while(ao!=0)
                    {
                        m = FindFileWithMinSegment(ao, ta);
                        f[ta[m]].Read(buffer, 0, buffer.Length);
                        f[t[j]].Write(buffer, 0, buffer.Length);
                        if (EndOfFile(f[ta[m]]))
                        {
                            FinishFile(ref af, ref ao, ref ta, m);
                        }
                        else //if (SegmentFinished)
                        {
                            FinishSegment(ref ao, ref ta, m);
                        }
                    }
                    j = NextOutputFileIndex(j);
                }
                t = SwitchIndexMap(t);
                Close(f0, f);
            }
            Finish(t);
        }

        void FinishFile(ref int af, ref int ao, ref List<int> ta, int m)
        {
            af = ModifyAF(af);
            ao = ModifyAO(ao);
            ta = ModifyTA(ta, m);
        }

        void FinishSegment(ref int ao, ref List<int> ta, int m)
        {
            ao = ModifyAO(ao);
            ta = ModifyTA(ta, m);
        }

        void Finish(int[] t)
        {
            Close(f0, f);
            string sortedDir = filePath + "\\BalancedMultiwayMerging_SORTED";
            Directory.CreateDirectory(sortedDir);
            File.Delete(sortedDir + "\\SORTED.txt");
            File.Copy(workPath + "\\f" + t[0].ToString() + ".txt", sortedDir + "\\SORTED.txt");
            Clean();
        }

        int[] InitializeIndexMap()
        {
            int[] t = new int[2 * N];
            for (int i = 0; i < 2 * N; i++)
            {
                t[i] = i;
            }
            return t;
        }

        bool EndOfFile(FileStream fileStream)
        {
            Byte[] array = new byte[1];
            if (ReadNoSeekModification(ref fileStream, ref array, 0, array.Length) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        int ModifyAF(int af)
        {
            af--;
            return af;
        }

        int ModifyAO(int ao)
        {
            ao--;
            return ao;
        }

        List<int> ModifyTA(List<int> ta, int m)
        {
            int tmp = ta[m];
            ta.RemoveAt(m);
            ta.Add(tmp);
            return ta;
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
            int N = indexMap.Length/2;
            int[] t_new = new int[2*N];
            for (int i = 0; i < N; i++)
            {
                t_new[i] = indexMap[i + N];
                t_new[i + N] = indexMap[i];
            }
            return t_new;
        }

        int NextOutputFileIndex(int index)
        {
            index++;
            if (index >= 2 * N)
            {
                index = N;
            }
            return index;
        }

        void Close(FileStream f0, FileStream[] f)
        {
            f0.Close();
            foreach(FileStream file in f)
            {
                file.Close();
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
