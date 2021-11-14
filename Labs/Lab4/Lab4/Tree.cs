using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    class Tree
    {
        public Branch root { get; set; }

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

        public int TopDownTraversal(Branch current,int size)
        {
            if(current != null)
            {
                size++;
                int left = TopDownTraversal(current.LeftChild,size);
                int right = TopDownTraversal(current.RightChild,size);
                if(left>right)
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

        int UpwardTraversal(Branch current, List<Branch> branches)
        {
            if (current != null)
            {
                int left = UpwardTraversal(current.LeftChild, branches);
                int right = UpwardTraversal(current.RightChild, branches);
                if (left + 1 == right)
                {
                    branches.Add(current);
                }
                return left + right + 1;
            }
            else
            {
                return 1;
            }
        }

        public int MixedTraversal(Branch current,int curLeaf,int numLeaf, TreeNodeCollection node)
        {
            if(current!=null)
            {
                curLeaf = MixedTraversal(current.LeftChild, curLeaf,numLeaf, node);
                if(current.IsLeaf())
                {
                    curLeaf++;
                    if(numLeaf==curLeaf)
                    {
                        node.Clear();
                        ShowBranch(node, root, current);
                        return numLeaf;
                    }
                }
                return MixedTraversal(current.RightChild, curLeaf,numLeaf,node);
            }
            else
            {
                return curLeaf;
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
            else if(currentBranch.code == code)
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

        public void Remove(string str)
        {
            Branch forDelete = Search(str);
            if(forDelete!=null)
            {
                if (forDelete.IsLeaf())
                {
                    if (forDelete == root)
                    {
                        root = null;
                    }
                    else
                    {
                        forDelete.Delete();
                    }
                }
                else if (forDelete.LeftChild == null)
                {
                    if (forDelete == root)
                    {
                        root = forDelete.RightChild;
                    }
                    forDelete = forDelete.RightChild;
                }
                else if (forDelete.RightChild == null)
                {
                    if (forDelete == root)
                    {
                        root = forDelete.LeftChild;
                    }
                    forDelete = forDelete.LeftChild;
                }
                else
                {
                    Branch maxBranch = SearchMax(forDelete.LeftChild);
                    forDelete.code = maxBranch.code;
                    maxBranch.Delete();
                }
            }
        }

        public Branch SearchMax(Branch currentBranch)
        {

            if(currentBranch.RightChild!=null)
            {
                return SearchMax(currentBranch.RightChild);
            }
            else
            {
                return currentBranch;
            }
        }




        public void ShowTree(TreeNodeCollection node)
        {
            ShowBranch(node, root);
        }
        void ShowBranch(TreeNodeCollection node, Branch currentBranch)
        {
            TreeNode nodeInside;
            AddNodeToTreeView(currentBranch, out nodeInside, node);
            TransitionToChild(currentBranch.LeftChild, nodeInside);
            TransitionToChild(currentBranch.RightChild, nodeInside);
        }
        void ShowBranch(TreeNodeCollection node, Branch currentBranch, Branch foundBranch)
        {
            TreeNode nodeInside;
            AddNodeToTreeView(currentBranch, out nodeInside, node);
            if (foundBranch == currentBranch)
            {
                nodeInside.BackColor = System.Drawing.Color.Red;
            }
            TransitionToChild(currentBranch.LeftChild, nodeInside, foundBranch);
            TransitionToChild(currentBranch.RightChild, nodeInside, foundBranch);
        }
        void AddNodeToTreeView(Branch currentBranch, out TreeNode nodeInside, TreeNodeCollection node)
        {
            nodeInside = node.Add("<" + currentBranch.code.str + ">");
        }
        void TransitionToChild(Branch childBranch, TreeNode nodeInside)
        {
            if (childBranch != null)
            {
                ShowBranch(nodeInside.Nodes, childBranch);
            }
        }
        void TransitionToChild(Branch childBranch, TreeNode nodeInside, Branch foundBranch)
        {
            if (childBranch != null)
            {
                ShowBranch(nodeInside.Nodes, childBranch, foundBranch);
            }
        }

    }
}
