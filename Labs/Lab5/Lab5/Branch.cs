using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Branch
    {
        public Code code { get; set; }
        public Branch LeftChild { get; set; }
        public Branch RightChild { get; set; }
        public Branch Parent { get; set; }

        public int P { get; set; }
        public int Q { get; set; }

        public bool IsLeaf()
        {
            if (LeftChild == null && RightChild == null)
            {
                return true;
            }
            return false;
        }

        public bool TwoChildren()
        {
            if (LeftChild!=null && RightChild!=null)
            {
                return true;
            }
            return false;
        }
         
        public int Size()
        {
            return TopDownTraversal(this, 0);
        }

        public int Discrepancy()
        {
            if (this.LeftChild != null && this.RightChild != null)
            {
                return this.LeftChild.Size() - this.RightChild.Size();
            }
            else if (this.LeftChild != null || this.RightChild != null)
            {
                if (this.LeftChild == null)
                {
                    return -this.RightChild.Size();
                }
                else
                {
                    return this.LeftChild.Size();
                }
            }
            return 0;
        }

        public int TopDownTraversal(Branch current, int size)
        {
            if (current != null)
            {
                size++;
                int left = TopDownTraversal(current.LeftChild, size);
                int right = TopDownTraversal(current.RightChild, size);
                if (left > right)
                {
                    return left;
                }
                else
                {
                    return right;
                }
            }
            return size;
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

        public Branch(string code, int p, int q)
        {
            this.code = new Code(code);
            P = p;
            Q = q;
        }
    }
}
