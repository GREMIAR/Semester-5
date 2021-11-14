using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Branch
    {
        public Code code { get; set; }
        public Branch LeftChild { get; set; }
        public Branch RightChild { get; set; }
        public Branch Parent { get; set; }

        public bool IsLeaf()
        {
            if (LeftChild == null && RightChild == null)
            {
                return true;
            }
            return false;
        }

        public void Delete()
        {
            if(this.Parent.LeftChild==this)
            {
                Parent.LeftChild = null;
            }
            else
            {
                Parent.RightChild = null;
            }
        }

        public Branch(Code code)
        {
            this.code = code;
        }

        public Branch(string code)
        {
            this.code = new Code(code);
        }
    }
}
