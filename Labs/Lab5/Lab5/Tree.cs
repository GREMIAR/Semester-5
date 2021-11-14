using System.Collections.Generic;
using System.Windows.Forms;

namespace Lab5
{
    class Tree
    {
        public Branch root { get; set; }

        int p;

        int q;

        List<Cost> cost = new List<Cost>();

        public void Insert(string str,int p,int q)
        {
            Code code = new Code(str);
            if(root!=null)
            {
                fix(SearchInsertionPoint(root, code, p, q));

            }
            else
            {
                root = new Branch(code,p,q);
            }
        }

        public void fix(Branch current)
        {
            if(current!=null)
            {
                int o = current.Discrepancy();
                if (current.Discrepancy() == 2)
                {
                    if (current.LeftChild.Discrepancy() < 0)
                    {
                        RotateL(current.LeftChild);
                    }
                    if (current == root)
                    {
                        root = RotateR(current);
                    }
                    else
                    {
                        RotateR(current);
                    }
                    return;
                }
                else if (current.Discrepancy() == -2)
                {
                    if (current.RightChild.Discrepancy() > 0)
                    {
                        RotateR(current.RightChild);
                    }
                    if (current == root)
                    {
                        root = RotateL(current);
                    }
                    else
                    {
                        RotateL(current);
                    }
                    return;
                }
                fix(current.Parent);
            }
            else
            {
                return;
            }
        }

        public Branch RotateR(Branch branch)
        {
            Branch newBranch = branch.LeftChild;
            branch.LeftChild = newBranch.RightChild;
            newBranch.RightChild = branch;
            if (branch.Parent != null)
            {
                if (branch.Parent.LeftChild == branch)
                {
                    branch.Parent.LeftChild = newBranch;
                }
                else
                {
                    branch.Parent.RightChild = newBranch;
                }
            }
            newBranch.Parent = branch.Parent;
            branch.Parent = newBranch;
            return newBranch;
        }

        public Branch RotateL(Branch branch)
        {
            Branch newBranch = branch.RightChild;
            branch.RightChild = newBranch.LeftChild;
            newBranch.LeftChild = branch;
            if(branch.Parent!=null)
            {
                if(branch.Parent.LeftChild==branch)
                {
                    branch.Parent.LeftChild = newBranch;
                }
                else
                {
                    branch.Parent.RightChild = newBranch;
                }
            }
            newBranch.Parent = branch.Parent;
            branch.Parent = newBranch;
            return newBranch;
        }

        public Branch SearchInsertionPoint(Branch currentBranch,Code code, int p, int q)
        {
            if (currentBranch.code>=code)
            {
                if (currentBranch.LeftChild==null)
                {
                    currentBranch.LeftChild = new Branch(code,p,q);
                    currentBranch.LeftChild.Parent = currentBranch;
                    return currentBranch;
                }
                else
                {
                    return SearchInsertionPoint(currentBranch.LeftChild,code,  p,  q);
                }
            }
            else
            {
                if (currentBranch.RightChild == null)
                {
                    currentBranch.RightChild = new Branch(code,p,q);
                    currentBranch.RightChild.Parent = currentBranch;
                    return currentBranch;
                }
                else
                {
                    return SearchInsertionPoint(currentBranch.RightChild, code, p, q);
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

        public int Cost(string str)
        {
            List<Cost> costs = new List<Cost>();
            costs.Add(new Cost(p, q, 0));
            Code code = new Code(str);
            SearchCost(root, code, ref costs);
            int result = 0;
            for(int i=1;i<costs.Count;i++)
            {
                result += costs[i].P * costs[i].Size;
            }

            for (int j = 0; j < costs.Count; j++)
            {
                result += costs[j].Q * (costs[j].Size-1);
            }
            return result;
        }


        public Branch SearchCost(Branch currentBranch, Code code,ref List<Cost> costs)
        {
            if (currentBranch == null)
            {
                return null;
            }
            else if (currentBranch.code == code)
            {
                costs.Add(new Cost(currentBranch.P, currentBranch.Q, currentBranch.Size()));
                return currentBranch;
            }
            else if (currentBranch.code < code)
            {
                costs.Add(new Cost(currentBranch.P, currentBranch.Q, currentBranch.Size()));
                return SearchCost(currentBranch.LeftChild, code, ref costs);
            }
            else
            {
                costs.Add(new Cost(currentBranch.P, currentBranch.Q, currentBranch.Size()));
                return SearchCost(currentBranch.RightChild, code, ref costs);
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
            if(currentBranch.Parent != null)
            {
                if(currentBranch.Parent.LeftChild == currentBranch)
                {
                    nodeInside = node.Add("L<" + currentBranch.code.str + ">");
                }
                else
                {
                    nodeInside = node.Add("R<" + currentBranch.code.str + ">");
                }
            }
            else
            {
                nodeInside = node.Add("<" + currentBranch.code.str + ">");
            }
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

        public Tree(int p,int q)
        {
            this.p = p;
            this.q = q;
        }

    }
}
