﻿using System.IO;
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
                pictureBox1.Refresh();
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
            Menu_click();
            Graph_click();
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
                OpenViaDialog();
            }
        }

        void RandomizeGraph_click()
        {
            if (MouseInsideRect(rects.RandomizeGraph))
            {
                RandomizeVertices();
            }
        }

        void Graph_click()
        {
            if (MouseInsideRect(rects.GraphArea))
            {
                if (matrix != null)
                {
                    Vertex currentVertex = matrix.NodeFirst;
                    while(currentVertex != null)
                    {
                        if (Control.ModifierKeys == Keys.None && MouseInsideRect(new Rectangle(currentVertex.Coor.X - rects.VertexArea.Width / 2, currentVertex.Coor.Y - rects.VertexArea.Height / 2, rects.VertexArea.Width, rects.VertexArea.Height)))
                        {
                            matrix.Remove(currentVertex);
                        }
                        currentVertex = currentVertex.Next;
                    }
                }
            }
        }

        void Menu_click()
        {
            if (MouseInsideRect(new Rectangle(0,0, pictureBox1.Width, rects.X.Height)))
            { 
                X_click();
                Hide_click();
                Open_click();
                RandomizeGraph_click();
                AddVertex_click();
            }
        }

        void AddVertex_click()
        {
           if (MouseInsideRect(rects.AddVertex))
            {
                // werfgthymj
            }
        }

    }
}
