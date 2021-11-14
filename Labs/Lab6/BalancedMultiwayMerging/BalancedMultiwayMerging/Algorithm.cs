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
            //BinaryWriter writer = new BinaryWriter(File.Open(filename, FileMode.Open));
            //FileStream reader = File.Open(filename, FileMode.Open);
            
            FileStream f0 = File.Open(filename, FileMode.Open);
            Byte[] f0_buffer = new byte[200];
            FileStream[] f = new FileStream[N];
            Directory.CreateDirectory(workPath);
            for(int i = 0; i < N; i++)
            {
                FileStream creating = File.Create(workPath + "\\f" + i.ToString());
                creating.Close();
                f[i] = File.Open(workPath + "\\f" + i.ToString(), FileMode.Open);
            }
            int j = 1;
            int L = 0;
            while (f0.Read(f0_buffer, 0, f0_buffer.Length) > 0)
            {
                f0.Read(f0_buffer, 0, f0_buffer.Length);
                f[j].Write(f0_buffer, 0, f0_buffer.Length);
                j++; // ???
                L++;
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
            }



            Close(f0, f);
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
