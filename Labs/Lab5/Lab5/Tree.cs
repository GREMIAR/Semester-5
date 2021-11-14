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
