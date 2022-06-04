using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Lab5
{
    public partial class MainForm : Form
    {
        Tree tree;
        public MainForm()
        {
            InitializeComponent();
            tree = new Tree();
            timeTest();
            //sizeTest();
            //TreeDrawing();
        }

        void timeTest()
        {
            Stopwatch stopwatch = new Stopwatch();
            for (int f = 1; f < 4000; f++)
            {
                test(f);
                stopwatch.Start();
                testSearch(f);
                stopwatch.Stop();
                tree = new Tree();
                File.AppendAllText("time.txt", stopwatch.Elapsed.TotalMilliseconds * 1000000 + Environment.NewLine);
                stopwatch.Reset();
            }
        }

        void sizeTest()
        {
            int r = 0;
            for (int f = 1; f < 4000; f++)
            {
                test(f);
                r += testSearchS(f);
                tree = new Tree();
                File.AppendAllText("size.txt", r + Environment.NewLine);
                r = 0;
            }
        }

        void testSearch(int count)
        {
            for (int i = 1; i < count + 1; i++)
            {
                tree.Search(i.ToString());
            }
        }

        int testSearchS(int count)
        {
            int countBranch = 0, s = 0;
            for (int i = 1; i < count + 1; i++)
            {
                tree.Search(tree.root,new Code(i.ToString()), ref countBranch, ref s);
            }
            return countBranch;
        }

        void test(int count)
        {
            for (int i = 1; i < count + 1; i++)
            {
                tree.Insert(i.ToString());
            }
            /*int countBranch = 0, s = 0;
            for (int i = 1; i < count + 1; i++)
            {
                tree.Search(tree.root, new Code(i.ToString()), ref countBranch, ref s);
            }*/
        }
        void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxAdd.Text != "")
            {
                tree.Insert(textBoxAdd.Text);
            }
            TreeDrawing();
        }
        
        void textBox_TextChanged(object sender, EventArgs e)
        {
            RemoveSpecialSymbols(sender);
        }

        void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            labelSearch.Text = "Вывод: "+ tree.Cost(textBoxSearch.Text).ToString();
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
            tree = new Tree(0,900);
            textBoxAdd.Text = string.Empty;
            textBoxSearch.Text = string.Empty;
            TreeDrawing();
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
