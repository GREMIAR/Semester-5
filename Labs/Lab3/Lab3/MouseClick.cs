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


        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            MouseIsDown = false;
            pictureBox1.Refresh();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            MouseIsDown = true;
            X_click();
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
