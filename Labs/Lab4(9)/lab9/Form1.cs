using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
namespace lab9
{
    public partial class Form1 : Form
    {
        int[] defaultInput = new int[] { 11, 4564, 65, 489, 946, 3215, 7864, 154, 12, 13 };

        HashTable<int> hashTable;
        public Form1()
        {
            InitializeComponent();
            hashTable = new HashTable<int>(defaultInput.Length);
        }
        delegate void Operation(int digit);
        
        void button1_Click(object sender, EventArgs e)
        {
            HashTableInput(chart1, "Диаграмма метода деления", hashTable.Division);
        }
        void button2_Click(object sender, EventArgs e)
        {
            HashTableInput(chart2, "Диаграмма метода умножения", hashTable.Multiplication);
        }
        void button3_Click(object sender, EventArgs e)
        {
            HashTableInput(chart3, "Диаграмма аддитивного метода", hashTable.Additive);
        }
        void button4_Click(object sender, EventArgs e)
        {
            HashTableInput(chart4, "Диаграмма метода исключающего ИЛИ", hashTable.XOR);
        }
        void HashTableInput(Chart chart, string name, Operation method)
        {
            hashTable.Clear();
            InputHashKey(method);
            DiagramName(name, chart);
            KeyInDiagram(hashTable, chart);
        }
        void InputHashKey(Operation function)
        {
            foreach (int digit in defaultInput)
            {
                function(digit);
            }
        }
        void DiagramName(string name, Chart chart)
        {
            chart.Series["Series1"].LegendText = name;
        }
        void KeyInDiagram(HashTable<int> hashTable, Chart chart)
        {
            for (int i = 0; i < hashTable.items.Length; i++)
            {
                chart.Series["Series1"].Points.AddXY(hashTable.items[i].Key, hashTable.items[i].Node.Count);
            }
        }
    }
}