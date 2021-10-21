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
        private bool MouseIsDown { get; set; }
        private Point mouseDownCoords { get; set; }

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
                X_click();
                Hide_click();
            }
        }


        void Hide_click()
        {
            if (MouseInsideRect(rects.Hide))
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


    }
}
