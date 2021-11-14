using System;
using System.Windows.Forms;

namespace Lab5
{
    public partial class MainForm : Form
    {
        Tree tree;
        public MainForm()
        {
            InitializeComponent();
            tree = new Tree(0,900);
            tree.Insert("1",100,500);
            tree.Insert("3", 350 , 600);
            tree.Insert("5", 700, 120);
            tree.Insert("7", 280 , 40);
            tree.Insert("9", 50, 50);
            tree.Insert("11", 300, 140);
            tree.Insert("13", 200, 230);
            tree.Insert("15", 150, 60);
            tree.Insert("17", 30, 300);
            tree.Insert("19", 400 , 110);
            TreeDrawing();
        }
        void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxAdd.Text != "")
            {
                tree.Insert(textBoxAdd.Text, 1, 1);
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
