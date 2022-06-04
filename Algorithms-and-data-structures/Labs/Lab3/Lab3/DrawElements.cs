using System.IO;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System;
using System.Drawing.Drawing2D;

namespace Lab3
{
    public partial class Form1
    {
        void DrawMinimize(PaintEventArgs e)
        {
            DrawBtn(e, rects.Minimize, true);
            e.Graphics.DrawLine(new Pen(colors.Text, 1), new Point(rects.Minimize.X + rects.Minimize.Width / 4, rects.Minimize.Y + rects.Minimize.Height * 3 / 4), new Point(rects.Minimize.X + rects.Minimize.Width * 3 / 4, rects.Minimize.Y + rects.Minimize.Height * 3 / 4));
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
            e.Graphics.DrawLine(new Pen(colors.Text, 1), new Point(x.X + x.Width / 4, x.Y + x.Height / 4), new Point(x.X + x.Width * 3 / 4, x.Y + x.Height * 3 / 4));
            e.Graphics.DrawLine(new Pen(colors.Text, 1), new Point(x.X + x.Width * 3 / 4, x.Y + x.Height / 4), new Point(x.X + x.Width / 4, x.Y + x.Height * 3 / 4));
        }

        void DrawOpen(PaintEventArgs e)
        {
            DrawBtn(e, rects.Open, true);
            DrawText(e, strings.BtnOpen, colors.Text, rects.Open);
        }

        void DrawRandomizeGraph(PaintEventArgs e)
        {
            DrawBtn(e, rects.RandomizeGraph, matrix!=null);
            DrawText(e, strings.BtnRandomizeGraph, colors.Text, rects.RandomizeGraph);
        }

        void DrawAddVertex(PaintEventArgs e)
        {
            DrawBtn(e, rects.AddVertex, true);
            DrawText(e, strings.BtnAddVertex, colors.Text, rects.AddVertex);
        }

        void DrawNewVertexName(PaintEventArgs e)
        {
            DrawTextBox(e, rects.NewVertexName, true);
            DrawTextInTextBox(e, userInput[strings.NewVertexName], colors.Text, rects.NewVertexName);
        }

        void DrawNewVertexPaths(PaintEventArgs e)
        {
            DrawTextBox(e, rects.NewVertexPaths, true);
            DrawTextInTextBox(e, userInput[strings.NewVertexPaths], colors.Text, rects.NewVertexPaths);
        }

        void DrawVertex(PaintEventArgs e, Vertex vertex)
        {
            if (MouseInsideRect(new Rectangle(vertex.Coor.X - rects.VertexArea.Width/2, vertex.Coor.Y - rects.VertexArea.Height/2, rects.VertexArea.Width, rects.VertexArea.Height)))
            {
                e.Graphics.FillEllipse(new SolidBrush(colors.VertexSelect), vertex.Coor.X - rects.Vertex.Width / 2, vertex.Coor.Y - rects.Vertex.Height / 2, rects.Vertex.Width, rects.Vertex.Height);
                SizeF stringSize = e.Graphics.MeasureString(strings.DeleteVertex + " " + vertex.Name, ourFont);
                DrawText(e, strings.DeleteVertex + " " + vertex.Name, colors.Text, new Rectangle(mouseCoords.X - (int)stringSize.Width/2, mouseCoords.Y - (int)stringSize.Height - 5, (int)stringSize.Width, (int)stringSize.Height));
            }
            else
            {
                e.Graphics.FillEllipse(new SolidBrush(colors.Vertex), vertex.Coor.X - rects.Vertex.Width/2, vertex.Coor.Y - rects.Vertex.Height / 2, rects.Vertex.Width, rects.Vertex.Height);
                SizeF stringSize = e.Graphics.MeasureString(vertex.Name, ourFont);
                DrawText(e, vertex.Name, colors.Text, new Rectangle(vertex.Coor.X - (int)stringSize.Width / 2, vertex.Coor.Y - (int)stringSize.Height - 5, (int)stringSize.Width, (int)stringSize.Height));
            }
        }


        void DrawEdge(PaintEventArgs e, Point fromCoords, Point toCoords)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Pen p = new Pen(colors.Edge);
            AdjustableArrowCap bigArrow = new AdjustableArrowCap(rects.Vertex.Width/2, rects.VertexArea.Height);
            p.CustomEndCap = bigArrow;
            g.DrawLine(p, fromCoords, toCoords);
            p.Dispose();
        }


        void DrawGraph(PaintEventArgs e)
        {
            if (matrix!=null)
            {
                Vertex currentVertex = matrix.NodeFirst;
                while(currentVertex != null)
                {
                    foreach(Vertex vertex in currentVertex.GetDirection())
                    {
                        DrawEdge(e, currentVertex.Coor, vertex.Coor);
                    }
                    currentVertex = currentVertex.Next;
                }
                currentVertex = matrix.NodeFirst;
                while (currentVertex != null)
                {
                    DrawVertex(e, currentVertex);
                    currentVertex = currentVertex.Next;
                }
            }
        }

    }
}
