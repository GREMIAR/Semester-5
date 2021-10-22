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
        void DrawMinimize(PaintEventArgs e)
        {
            DrawBtn(e, rects.Minimize);
            e.Graphics.DrawLine(new Pen(colors.Edge, 1), new Point(rects.Minimize.X + rects.Minimize.Width / 4, rects.Minimize.Y + rects.Minimize.Height * 3 / 4), new Point(rects.Minimize.X + rects.Minimize.Width * 3 / 4, rects.Minimize.Y + rects.Minimize.Height * 3 / 4));
        }

        void DrawBackground(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(colors.Background), 0, 0, pictureBox1.Width, pictureBox1.Height);
        }

        void DrawFrame(PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(colors.Frame, 3), 0, 0, pictureBox1.Width, pictureBox1.Height);
        }

        void DrawX(PaintEventArgs e)
        {
            Rectangle x = rects.X;
            if (MouseInsideRect(x))
            {
                e.Graphics.FillRectangle(new SolidBrush(colors.Select), x);
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(colors.Background), x);
            }
            e.Graphics.DrawLine(new Pen(colors.Edge, 1), new Point(x.X + x.Width / 4, x.Y + x.Height / 4), new Point(x.X + x.Width * 3 / 4, x.Y + x.Height * 3 / 4));
            e.Graphics.DrawLine(new Pen(colors.Edge, 1), new Point(x.X + x.Width * 3 / 4, x.Y + x.Height / 4), new Point(x.X + x.Width / 4, x.Y + x.Height * 3 / 4));
        }

        void DrawOpen(PaintEventArgs e)
        {
            DrawBtn(e, rects.Open);
            DrawText(e, strings.BtnOpen, colors.Text, rects.Open);
        }

    }
}
