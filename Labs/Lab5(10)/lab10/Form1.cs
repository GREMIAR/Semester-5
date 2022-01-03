using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace lab10
{
    public partial class Form1 : Form
    {
        HashTable hashTable;

        List<int> list;
        public Form1()
        {
            InitializeComponent();
            hashTable = new HashTable();
            list = new List<int>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Int32.TryParse(textBox1.Text, out int digit))
            {
                list.Add(digit);
                label3.Text = "Количество ключей:" + (list.Count + 1);
            }
            else
            {
                Random random = new Random();
                list.Add(random.Next(0, 1000));
                label2.Text = list[list.Count - 1].ToString();
                label3.Text = "Количество ключей:" + list.Count;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HashTableInput(hashTable.LinearDivision);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HashTableInput(hashTable.QuadraticDivison);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            HashTableInput(hashTable.LinearMultiplication);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            HashTableInput(hashTable.QuadraticMultiplication);
        }

        void HashTableInput(HashFunction hashFunction)
        {
            chart1.Series["Series1"].LegendText = " ";
            hashTable.SwitchTypeHash(hashFunction,list);
            chart1.Series.Clear();
            chart1.Series.Add("Series1");
            for (int i = 0; i < hashTable.items.Length; i++)
            {
                chart1.Series["Series1"].Points.AddXY(hashTable.items[i].Key, hashTable.items[i].Value);
            }
        }
    }
}
