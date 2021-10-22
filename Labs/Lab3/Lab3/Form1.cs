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
            /*if (str.Length>0)
            {
                dataTable = ReadExcelFile.ReadExcel(str[0].Substring(0, str[0].LastIndexOf('.')), str[0].Substring(str[0].LastIndexOf('.')));
            }
            else
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "|*.xlsx;.xls";
                if(openFileDialog.ShowDialog() == DialogResult.OK)
                { 
                    dataTable = ReadExcelFile.ReadExcel(openFileDialog.FileName.Substring(0, openFileDialog.FileName.LastIndexOf('.')), openFileDialog.FileName.Substring(openFileDialog.FileName.LastIndexOf('.')));
                }
                else
                {
                    Application.Exit();
                }
            }*/
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            SetStartValues();
            pictureBox1.Refresh();
        }
    }
}
