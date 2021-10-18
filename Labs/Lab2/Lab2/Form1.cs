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
            int idColumn = 1;
            int id = int.Parse(dataGridView2.Rows[0].Cells[idColumn].Value.ToString());
            string lastName = dataGridView2.Rows[0].Cells[idColumn+1].Value.ToString();
            int examFirst = int.Parse(dataGridView2.Rows[0].Cells[idColumn+2].Value.ToString());
            int examSecond = int.Parse(dataGridView2.Rows[0].Cells[idColumn+3].Value.ToString());
            int examThird = int.Parse(dataGridView2.Rows[0].Cells[idColumn+4].Value.ToString());
            bool redDiploma = bool.Parse(dataGridView2.Rows[0].Cells[idColumn+5].Value.ToString());
            string city = dataGridView2.Rows[0].Cells[idColumn+6].Value.ToString();
            bool needHousing = bool.Parse(dataGridView2.Rows[0].Cells[idColumn+7].Value.ToString());
            ml_List.Insert(new Student(id, lastName, examFirst, examSecond, examThird, redDiploma, city, needHousing));
        }

        private void Remove_CLick(DataGridViewCellEventArgs e)
        {
            ml_List.Remove(int.Parse(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()));
            RefreshTable();
        }

        private void RefreshTable()
        {
            dataGridView1.Rows.Clear();
            Node curNode = ml_List.head;
            while(curNode!=null)
            {
                AddRow(curNode);
                curNode = curNode.next;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (senderGrid.Columns[e.ColumnIndex].Name=="Remove")
                {
                    Remove_CLick(e);
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
                RefreshTable();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView2.Rows.Add();
            dataGridView2.Rows[dataGridView2.RowCount - 1].ReadOnly = false;
            
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView2.CurrentCell.ReadOnly = false;
        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView2.CurrentCell.ReadOnly = true;
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            RefreshTable();
        }

        private void FilterAllExams5_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            Node curNode = ml_List.head;
            while (curNode != null)
            {
                if (curNode.student.examFirst >= 80 && curNode.student.examSecond >= 80 && curNode.student.examThird >= 80)
                {
                    AddRow(curNode);
                }
                curNode = curNode.next;
            }
        }

        private void FilterDiploma_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            Node curNode = ml_List.redDiploma;
            while (curNode != null)
            {
                AddRow(curNode);
                curNode = curNode.Diploma;
            }
        }

        private void ForeignCity_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            Node curNode = ml_List.head;
            while (curNode != null)
            {
                if (curNode.student.city != "Орёл")
                {
                    AddRow(curNode);
                }
                curNode = curNode.next;
            }
        }

        private void NeedsHousing_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            Node curNode = ml_List.needHousing;
            while (curNode != null)
            {
                AddRow(curNode);
                curNode = curNode.Housing;
            }
        }

        private void AddRow(Node curNode)
        {
            dataGridView1.Rows.Add();
            dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[1].Value = curNode.student.id;
            dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[2].Value = curNode.student.lastName;
            dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[3].Value = curNode.student.examFirst;
            dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[4].Value = curNode.student.examSecond;
            dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[5].Value = curNode.student.examThird;
            dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[6].Value = curNode.student.redDiploma;
            dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[7].Value = curNode.student.city;
            dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[8].Value = curNode.student.needHousing;
        }
    }
}
