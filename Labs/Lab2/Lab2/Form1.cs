using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Form1 : Form
    {
        MultiLinkedList ml_List = new MultiLinkedList();
        public Form1()
        {
            InitializeComponent();


            ml_List.Insert(new Student(1, "Фам1", 90, 90, 49, true, "Орёл", false));
            ml_List.Insert(new Student(2, "Фам", 91, 90, 49, false, "Мценск", false));
            ml_List.Insert(new Student(3, "Фам3", 92, 90, 49, false, "Брянск", true));
            ml_List.Insert(new Student(4, "Фам4", 90, 93, 49, true, "Орёл", false));
            ml_List.Insert(new Student(5, "Фам5", 90, 94, 49, true, "Орёл", true));

            RefreshTable();
        }

        private void PushForward_Click()
        {
            
        }

        private void Remove_CLick(int row)
        {

        }

        private void Filter_Click()
        {

        }

        private void RefreshTable()
        {
            Node curNode = ml_List.head;
            while(curNode!=null)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[1].Value = curNode.student.id;
                dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[2].Value = curNode.student.lastName;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (senderGrid.Columns[e.ColumnIndex].Name=="Remove")
                {
                    Remove_CLick(e.RowIndex);
                }
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (senderGrid.Columns[e.ColumnIndex].Name == "PushForwardBtn")
                {
                    PushForward_Click();
                }
                else if (senderGrid.Columns[e.ColumnIndex].Name == "Filter")
                {
                    Filter_Click();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView2.Rows.Add();

            
        }
    }
}
