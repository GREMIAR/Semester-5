using System;
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
        void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
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

        void buttonRandom_Click(object sender, EventArgs e)
        {
            treeBox.SuspendLayout();
            Int32.TryParse(textBoxSearch.Text, out int leaf);
            tree.MixedTraversal(tree.root,0, leaf, treeBox.Nodes).ToString();
            treeBox.ExpandAll();
            treeBox.ResumeLayout();
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

    }
}
