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
        void ResetMouseCoords()
        {
            mouseCoords = new Point(-1, -1);
        }

        void SetMouseCoords(MouseEventArgs e)
        {
            mouseCoords = new Point(e.X, e.Y);
        }

        bool MouseInsideRect(Rectangle rect)
        {
            if (mouseCoords.X >= rect.X && mouseCoords.X <= rect.X + rect.Width && mouseCoords.Y >= rect.Y && mouseCoords.Y <= rect.Y + rect.Height)
            {
                return true;
            }
            return false;
        }

        void SetLocAndSizeOfPB()
        {
            pictureBox1.Location = new Point(rects.PictureBox1.X, rects.PictureBox1.Y);
            pictureBox1.Width = rects.PictureBox1.Width;
            pictureBox1.Height = rects.PictureBox1.Height;
        }

        void MoveWindowStart()
        {
            if (Math.Abs(mouseCoords.X - rects.PictureBox1.X) < 10 || Math.Abs(mouseCoords.X - (rects.PictureBox1.X + rects.PictureBox1.Width)) < 10 || Math.Abs(mouseCoords.Y - rects.PictureBox1.Y) < 10 || Math.Abs(mouseCoords.Y - (rects.PictureBox1.Y + rects.PictureBox1.Height)) < 10)
            {
                movingWindow = true;
            }
        }

        void MoveWindowFinish()
        {
            movingWindow = false;
        }

        void MoveWindow(MouseEventArgs e)
        {
            if (movingWindow && e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mouseDownCoords.X, this.Location.Y + e.Y - mouseDownCoords.Y);
            }
        }
    }
}
