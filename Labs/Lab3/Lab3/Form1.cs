using System.IO;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System;

namespace Lab3
{
    public partial class Form1 : Form
    {
        public Form1(string[] str)
        {
            InitializeComponent();
            if (str.Length>0)
            {
                dataTable = ReadExcelFile.ReadExcel(str[0].Substring(0, str[0].LastIndexOf('.')), str[0].Substring(str[0].LastIndexOf('.')));
                DataTableIsFilled = true;
                RandomizeVertices();
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            SetStartValues();
            pictureBox1.Refresh();
        }

        void OpenViaDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "|*.xlsx;*.xls";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog.FileName.Substring(0, openFileDialog.FileName.LastIndexOf('.'));
                string ext = openFileDialog.FileName.Substring(openFileDialog.FileName.LastIndexOf('.'));
                dataTable = ReadExcelFile.ReadExcel(filename, ext);
            }
            DataTableIsFilled = true;
            RandomizeVertices();
        }

        // Чтоб занести в матрицу Matrix, надо передать массив строк (названий) вершин. Потом соединить вершины с помощью SetDirection(string from, string to)
        void RandomizeVertices()
        {
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                vertices.Add(new Point(rnd.Next(rects.GraphArea.X, rects.GraphArea.X + rects.GraphArea.Width), rnd.Next(rects.GraphArea.Y, rects.GraphArea.Y + rects.GraphArea.Height)));
            }
        }
    }
}
