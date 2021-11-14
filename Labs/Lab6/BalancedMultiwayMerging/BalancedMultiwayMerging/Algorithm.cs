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
            FileStream f0 = File.Open(filename, FileMode.Open); // Открыть для чтения f0
            Byte[] f0_buffer = new byte[200];
            FileStream[] f = new FileStream[2*N];
            Directory.CreateDirectory(workPath);
            for(int i = 0; i < 2*N; i++)
            {
                FileStream creating = File.Create(workPath + "\\f" + i.ToString());
                creating.Close();
            }
            for (int i = 0; i < N; i++)
            {
                f[i] = File.Open(workPath + "\\f" + i.ToString(), FileMode.Open); // Открыть для записи f[1]..f[N]
            }
            int j = 1; // j := 1
            int L = 0; // L := 0
            //начальное распределение отрезков
            while (f0.Read(f0_buffer, 0, f0_buffer.Length) > 0) // until конец f0
            {
                f0.Read(f0_buffer, 0, f0_buffer.Length); 
                f[j].Write(f0_buffer, 0, f0_buffer.Length); // копировать отрезок из f0 в f[j]
                j++; // переключить j на следующий выходной файл
                L++;
            } 
            int af;
            int[] t = new int[2 * N];
            for (int i = 0; i < 2*N; i++)
            {
                t[i] = i; // выполнить начальную инициализацию индексной карты
            }
            // слияние из f[t[1]].. f[t[N]] в f[t[N+1]].. f[t[2N]]
            while (L != 1) // until L == 1
            {
                af = Math.Min(L, N); // af := min(L, N)
                // открыть для чтения f[t[1]].. f[t[af]] 
                // открыть для записи f[t[N+1]].. f[t[2N]] 
                // инициализировать ta[1].. ta[af] индексами из ta[] 
                // L := 0
                // j := N+1
            }

            Close(f0, f);
            Clean();
        }

        void f_Open(ref FileStream[] f, int[] fileIndex)
        {
            foreach(int i in fileIndex)
            {
                f[fileIndex[i]] = File.Open(workPath + "\\f" + (fileIndex[i]).ToString(), FileMode.Open);
            }
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
