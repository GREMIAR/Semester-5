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
        public Form1()
        {
            InitializeComponent();
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
            for(int i = 0; i < dataGridView1.RowCount; i++)
            {
                //dataGridView1
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
