using System.IO;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System;

namespace Lab3
{
    public partial class Form1
    {
        

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MouseIsDown = false;
                MoveWindowFinish();
                pictureBox1.Refresh();
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MouseIsDown = true;
                mouseDownCoords = e.Location;
                MoveWindowStart();
                BtnClicks();
            }
        }



        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            MoveWindow(e);
            SetMouseCoords(e);
            pictureBox1.Refresh();
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            ResetMouseCoords();
            pictureBox1.Refresh();
        }


        void BtnClicks()
        {
            X_click();
            Hide_click();
            Open_click();
        }

        void Hide_click()
        {
            if (MouseInsideRect(rects.Minimize))
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        void X_click()
        {
            if (MouseInsideRect(rects.X))
            {
                Application.Exit();
            }
        }


        void Open_click()
        {
            if (MouseInsideRect(rects.Open))
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "|*.xlsx;.xls";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    dataTable = ReadExcelFile.ReadExcel(openFileDialog.FileName.Substring(0, openFileDialog.FileName.LastIndexOf('.')), openFileDialog.FileName.Substring(openFileDialog.FileName.LastIndexOf('.')));
                }
            }
        }

    }
}
