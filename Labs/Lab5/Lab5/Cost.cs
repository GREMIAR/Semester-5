using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    internal class Cost
    {
        public int P { get; set; }
        public int Q { get; set; }

        public int Size { get; set; }

        public Cost(int p, int q, int size)
        {
            P = p;
            Q = q;
            Size = size;
        }
    }
}
