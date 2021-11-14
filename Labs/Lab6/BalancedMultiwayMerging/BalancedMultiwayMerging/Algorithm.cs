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
        int mergeWays;

        public Algorithm(string filename, int mergeWays)
        {
            this.filename = filename;
            this.mergeWays = mergeWays;
        }
        public void Sort()
        {
            //BinaryWriter writer = new BinaryWriter(File.Open(filename, FileMode.Open));
            //FileStream reader = File.Open(filename, FileMode.Open);
            
            FileStream f0 = File.Open(filename, FileMode.Open);
            FileStream[] f = new FileStream[mergeWays];
            for(int i = 0; i < mergeWays; i++)
            {
                if (true)
                {

                }
                //f[i] = File.Open(filename.Substring())
            }

        }
    }
}
