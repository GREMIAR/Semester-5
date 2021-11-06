using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Tree
    {
        Branch root { get; set; }

        public void Insert(string str)
        {
            Code code = new Code(str);
            if(root!=null)
            {
                SearchInsertionPoint(root, code);
            }
            else
            {
                root = new Branch(code);
            }
        }

        public void SearchInsertionPoint(Branch currentBranch,Code code)
        {
            if (currentBranch.code<=code)
            {
                if (currentBranch.LeftChild==null)
                {
                    currentBranch.LeftChild = new Branch(code);
                    currentBranch.LeftChild.Parent = currentBranch;
                }
                else
                {
                    SearchInsertionPoint(currentBranch.LeftChild,code);
                }
            }
            else
            {
                if (currentBranch.RightChild == null)
                {
                    currentBranch.RightChild = new Branch(code);
                    currentBranch.RightChild.Parent = currentBranch;
                }
                else
                {
                    SearchInsertionPoint(currentBranch.RightChild, code);
                }
            }
        }

        public Branch Search(string str)
        {
            Code code = new Code(str);
            return Search(root, code);
        }

        public Branch Search(Branch currentBranch, Code code)
        {
            if(currentBranch == null)
            {
                return null;
            }
            if(currentBranch.code == code)
            {
                return currentBranch;
            }
            else if (currentBranch.code<code)
            {
                return Search(currentBranch.LeftChild,code);
            }
            else
            {
                return Search(currentBranch.RightChild, code);
            }
        }

        //переделать чтобы возвращал только код, и сделать отдельные случаи.(правый\\//\\левый)
        public void Remove(string str)
        {
            Branch forDelete = Search(str);
            if(forDelete!=null)
            {
                Branch newBranch = SearchMax(forDelete);
                if(forDelete == root)
                {
                    root = newBranch;
                }
                if(forDelete.Parent.LeftChild == forDelete)
                {
                    newBranch.Parent = forDelete.Parent;
                    forDelete.code = newBranch.code;
                }
                else
                {
                    forDelete.Parent.RightChild = newBranch;
                }
            }
        }

        public Branch SearchMax(Branch currentBranch)
        {
            if (currentBranch == null)
            {
                if (currentBranch.Parent.RightChild!=null)
                {
                    return currentBranch.Parent.RightChild;
                }
                return null;
            }
            else if (currentBranch.RightChild == null)
            {
                return currentBranch;
            }
            else
            {
                return SearchMax(currentBranch.RightChild);
            }
        }
    }
}
