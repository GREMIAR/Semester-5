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
            for(int i = 0; i < 2*N; i++)
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
            int length;
            while ((length = f0.Read(buffer, 0, buffer.Length)) > 0)
            {
                f[j].Write(buffer, 0, length);
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
                        for(int i = 0; i < ao-1; i++)
                        {
                            Byte[] buffer1 = new byte[buffer.Length];
                            Byte[] buffer2 = new byte[buffer.Length];
                            f[i].Read(buffer1, 0, buffer1.Length);
                            f[i + 1].Read(buffer2, 0, buffer2.Length);
                            int first = int.Parse(System.Text.Encoding.Default.GetString(buffer1).Substring(0, sizeof(int)));
                            int second = int.Parse(System.Text.Encoding.Default.GetString(buffer2).Substring(0, sizeof(int)));
                            if (second < first)
                            {
                                m = i + 1;
                            }
                        }
                        f[ta[m]].Seek((f[ta[m]].Position-buffer.Length), SeekOrigin.Begin);
                        int readByteLength = f[ta[m]].Read(buffer, 0, buffer.Length);
                        f[t[j]].Write(buffer, 0, buffer.Length);
                        if (readByteLength == 0)
                        {
                            af--;
                            ao--;
                            int tmp = ta[m];
                            ta.RemoveAt(m);
                            ta.Add(tmp);
                        }
                        else
                        {
                            // нет ифа если кончился отрезок, че за отрезок кек
                            ao--;
                            int tmp = ta[m];
                            ta.RemoveAt(m);
                            ta.Add(tmp);
                        }
                    }
                    j++;
                    if (j >= 2*N)
                    {
                        j = N;
                    }
                }
                int[] t_new = new int[2 * N];
                for(int i = 0; i < N; i++)
                {
                    t_new[i] = t[i + N];
                    t_new[i + N] = t[i];
                }
                t = t_new;
            }
            Close(f0, f);
            string sortedDir = filePath + "\\BalancedMultiwayMerging_SORTED";
            Directory.CreateDirectory(sortedDir);
            File.Delete(sortedDir + "\\SORTED.txt");
            File.Copy(workPath + "\\f" + t[0].ToString() + ".txt", sortedDir + "\\SORTED.txt");
            Clean();
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
