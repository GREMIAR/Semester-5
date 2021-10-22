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
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            PaintStaticBefore(e);
            PaintDynamic(e);
            PaintStaticAfter(e);
        }

        void PaintStaticBefore(PaintEventArgs e)
        {
            DrawBackground(e);
        }

        void PaintDynamic(PaintEventArgs e)
        {
            DrawX(e);
            DrawMinimize(e);
            DrawOpen(e);
        }

        void PaintStaticAfter(PaintEventArgs e)
        {
            DrawFrame(e);
        }
    }
}
