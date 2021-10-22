using System.IO;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System;
using System.Linq;

namespace Lab3
{
    public partial class Form1 : Form
    {
        public Form1(string[] str)
        {
            InitializeComponent();
            if (str.Length>0)
            {
                ReadExcel(str[0]);
                RandomizeVertices();
            }
        }

        public void ReadExcel(string fileName)
        {
            string[] fullFile = File.ReadAllLines(fileName);
            matrix = new Matrix(fullFile[0].Split(' ').Skip(1).ToArray());
            for (int i=1;i< fullFile.Length;i++)
            {
                string[] line = fullFile[i].Split(' ');
                string vertex = line[0];
                for (int f=1;f<=matrix.Size();f++)
                {
                    if (line[f]=="1")
                    {
                        matrix.SetDirection(vertex,matrix.GetVertex(f));
                    }
                }
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
            openFileDialog.Filter = "|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ReadExcel(openFileDialog.FileName);
            }
            RandomizeVertices();
        }

        void RandomizeVertices()
        {
            if (matrix != null)
            {
                Vertex vertex = matrix.NodeFirst;
                while(vertex != null)
                {
                    vertex.Coor = new Point(rnd.Next(rects.GraphArea.X, rects.GraphArea.X + rects.GraphArea.Width), rnd.Next(rects.GraphArea.Y, rects.GraphArea.Y + rects.GraphArea.Height));
                    vertex = vertex.Next;
                }
            }
        }

        
    }
}
