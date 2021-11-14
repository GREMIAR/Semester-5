using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Lab4
{
    public partial class MainForm : Form
    {
        Tree tree;
        public MainForm()
        {
            InitializeComponent();
            tree = new Tree();
        }
        void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxAdd.Text != "")
            {
                tree.Insert(textBoxAdd.Text);
            }
            TreeDrawing();
        }
        void textBoxAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonAdd_Click(sender, e);
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                textBoxSearch.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                textBoxDel.Focus();
            }
        }

        void buttonDel_Click(object sender, EventArgs e)
        {
            if (textBoxDel.Text != "")
            {
                tree.Remove(textBoxDel.Text);
            }
            TreeDrawing();
        }
        void textBoxDel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonDel_Click(sender, e);
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                textBoxAdd.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                textBoxSearch.Focus();
            }
        }
        void textBox_TextChanged(object sender, EventArgs e)
        {
            RemoveSpecialSymbols(sender);
        }
        void textBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                textBoxDel.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                textBoxAdd.Focus();
            }
        }
        void RemoveSpecialSymbols(object sender)
        {
            TextBox textBox = (TextBox)sender;
            int cursor = textBox.SelectionStart;
            textBox.Text = textBox.Text.Replace("<", "");
            textBox.Text = textBox.Text.Replace(">", "");
            textBox.SelectionStart = cursor;
        }
        void buttonClear_Click(object sender, EventArgs e)
        {
            tree = new Tree();
            textBoxAdd.Text = string.Empty;
            textBoxDel.Text = string.Empty;
            textBoxSearch.Text = string.Empty;
            TreeDrawing();
        }

        void buttonVertex_Click(object sender, EventArgs e)
        {
            textBoxSearch.Text = "";
            List<Branch> branches = new List<Branch>();
            tree.UpwardTraversal(tree.root, ref branches);
            foreach (Branch branch in branches)
            {
                textBoxSearch.Text += branch.code.str + "; ";
            }
        }

        public void TreeDrawing()
        {
            treeBox.Nodes.Clear();
            if (tree.root != null)
            {
                tree.ShowTree(treeBox.Nodes);
            }
            treeBox.ExpandAll();
        }

        private void buttonSize_Click(object sender, EventArgs e)
        {
            textBoxSearch.Text = tree.TopDownTraversal(tree.root, 0).ToString();
        }

        private void buttonLeafK_Click(object sender, EventArgs e)
        {
            Int32.TryParse(textBoxLeafK.Text, out int leaf);
            int y = tree.MixedTraversal(tree.root, 0, leaf, treeBox.Nodes);
            if (leaf != y)
            {
                TreeDrawing();
            }
            treeBox.ExpandAll();
        }
    }
}
