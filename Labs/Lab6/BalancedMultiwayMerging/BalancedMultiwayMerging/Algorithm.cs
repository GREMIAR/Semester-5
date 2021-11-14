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
            Byte[] buffer = new byte[200];
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
                }
                for (int i = N; i < 2*N; i++)
                {
                    f[t[i]] = File.Open(workPath + "\\f" + (t[i]).ToString() + ".txt", FileMode.Open); // для записи
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
                        for(int i = 0; i < af-1; i++)
                        {
                            Byte[] buffer_1 = new byte[200];
                            Byte[] buffer_2 = new byte[200];
                            f[i + 1].Read(buffer_1, 0, buffer_1.Length);
                            f[i].Read(buffer_2, 0, buffer_2.Length);
                            // вообще помойка а ведь это самое главное
                            if (int.Parse(System.Text.Encoding.Default.GetString(buffer_1)) < int.Parse(System.Text.Encoding.Default.GetString(buffer_2)))
                            {
                                m = i + 1;
                            }
                        }
                        f[ta[m]].Read(buffer, 0, buffer.Length);
                        f[t[j]].Write(buffer, 0, buffer.Length);
                        if (f[ta[m]].Read(buffer, 0, buffer.Length) == 0)
                        {
                            af--;
                            ao--;
                            ta.RemoveAt(m);
                        }
                        else
                        {
                            // нет ифа если кончился отрезок, че за отрезок кек
                            ao--;
                            ta.RemoveAt(m);
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
