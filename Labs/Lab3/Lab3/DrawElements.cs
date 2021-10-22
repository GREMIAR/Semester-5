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
            DrawBtn(e, rects.Minimize, true);
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
            DrawBtn(e, rects.X, true);
            Rectangle x = rects.X;
            e.Graphics.DrawLine(new Pen(colors.Edge, 1), new Point(x.X + x.Width / 4, x.Y + x.Height / 4), new Point(x.X + x.Width * 3 / 4, x.Y + x.Height * 3 / 4));
            e.Graphics.DrawLine(new Pen(colors.Edge, 1), new Point(x.X + x.Width * 3 / 4, x.Y + x.Height / 4), new Point(x.X + x.Width / 4, x.Y + x.Height * 3 / 4));
        }

        void DrawOpen(PaintEventArgs e)
        {
            DrawBtn(e, rects.Open, true);
            DrawText(e, strings.BtnOpen, colors.Text, rects.Open);
        }

        void DrawRandomizeGraph(PaintEventArgs e)
        {
            DrawBtn(e, rects.RandomizeGraph, DataTableIsFilled);
            DrawText(e, strings.BtnRandomizeGraph, colors.Text, rects.RandomizeGraph);

        }

        void DrawVertex(PaintEventArgs e, Point location)
        {
            e.Graphics.FillEllipse(new SolidBrush(colors.Vertex), location.X, location.Y, rects.Vertex.Width, rects.Vertex.Height);
        }

        void DrawEdge(PaintEventArgs e)
        {

        }

        void DrawGraph(PaintEventArgs e)
        {
            // edges first

            Vertex vertex = matrix.NodeFirst;
            while(vertex != null)
            {
                vertex.FindDirection
                vertex = vertex.Next;
            }



            for (int column = 0; column < matrix.Size(); column++)
            {
                vertex.FindDirection
            }

            //then vertices
            for (int i = 0; i < vertices.Count; i++)
            {
                DrawVertex(e, vertices[i]);
            }
        }

    }
}
