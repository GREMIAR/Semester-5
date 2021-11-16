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

        public Algorithm(string filename, int mergeWays, bool cleanRequired)
        {
            this.filename = filename;
            this.N = mergeWays;
            this.cleanRequired = cleanRequired;
            this.filePath = filename.Substring(0, filename.LastIndexOf("\\"));
            this.workPath = filePath + "\\BalancedMultiwayMerging_Files";
        }
        public void Sort()
        {
            FileStream f0 = File.Open(filename, FileMode.Open); // для чтения
            Byte[] buffer = new byte[sizeof(int)];
            FileStream[] f = new FileStream[2*N];
            Directory.CreateDirectory(workPath);
            for(int i = 0; i < 2 * N; i++)
            {
                FileStream creating = File.Create(workPath + "\\f" + i.ToString() + ".txt");
                creating.Close();
            }
            for (int i = 0; i < N; i++)
            {
                f[i] = File.Open(workPath + "\\f" + i.ToString() + ".txt", FileMode.Open); // для записи
            }
            int j = 0;
            int L = 0;
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
            int af;
            int[] t = new int[2 * N];
            for (int i = 0; i < 2*N; i++)
            {
                t[i] = i;
            }
            while (L != 1)
            {
                af = Math.Min(L, N);
                for (int i = 0; i < af; i++)
                {
                    f[t[i]] = File.Open(workPath + "\\f" + (t[i]).ToString() + ".txt", FileMode.Open); // для чтения
                    f[t[i]].Seek(0, SeekOrigin.Begin);
                }
                for (int i = N; i < 2*N; i++)
                {
                    f[t[i]] = File.Open(workPath + "\\f" + (t[i]).ToString() + ".txt", FileMode.Open); // для записи
                    f[t[i]].Seek(0, SeekOrigin.Begin);
                }
                List<int> ta = new List<int>();
                for (int i = 0; i < N; i++)
                {
                    ta.Add(i);
                }
                for (int i = 0; i < af; i++)
                {
                    ta[i] = i;
                }
                L = 0;
                j = N;
                int ao;
                while(af!=0)
                {
                    L++;
                    ao = af;
                    int m;
                    while(ao!=0)
                    {
                        m = 0;
                        for (int i = 0; i < ao-1; i++)
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
                        f[ta[m]].Read(buffer, 0, buffer.Length);
                        f[t[j]].Write(buffer, 0, buffer.Length);
                        if (EndOfFile(f[ta[m]]))
                        {
                            af = ModifyAF(af);
                            ao = ModifyAO(ao);
                            ta = ModifyTA(ta, m);
                        }
                        else
                        {
                            if (true) // если кончился отрезок, пока что в отрезке по одной записи так что стоит true
                            {
                                ao = ModifyAO(ao);
                                ta = ModifyTA(ta, m);
                            }
                        }
                    }
                    j = NextOutputFileIndex(j, N);
                }
                t = SwitchIndexMap(t);
                Close(f0, f);
            }
            Close(f0, f);
            string sortedDir = filePath + "\\BalancedMultiwayMerging_SORTED";
            Directory.CreateDirectory(sortedDir);
            File.Delete(sortedDir + "\\SORTED.txt");
            File.Copy(workPath + "\\f" + t[0].ToString() + ".txt", sortedDir + "\\SORTED.txt");
            Clean();
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

        int NextOutputFileIndex(int index, int N)
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
