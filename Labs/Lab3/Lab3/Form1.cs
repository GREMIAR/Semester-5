using System.IO;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System;

namespace Lab3
{
    public partial class Form1 : Form
    {
        public Form1(string[] str)
        {
            DataTable dataTable;
            InitializeComponent();
            /*if (str.Length>0)
            {
                dataTable = ReadExcelFile.ReadExcel(str[0].Substring(0, str[0].LastIndexOf('.')), str[0].Substring(str[0].LastIndexOf('.')));
            }
            else
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "|*.xlsx;.xls";
                if(openFileDialog.ShowDialog() == DialogResult.OK)
                { 
                    dataTable = ReadExcelFile.ReadExcel(openFileDialog.FileName.Substring(0, openFileDialog.FileName.LastIndexOf('.')), openFileDialog.FileName.Substring(openFileDialog.FileName.LastIndexOf('.')));
                }
                else
                {
                    Application.Exit();
                }
            }*/
        }

        Colors colors = new Colors();


        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            PaintStaticBefore(e);
            PaintDynamic(e);
            PaintStaticAfter(e);

            //DrawText(e, "Test\nKEEEEEEEEEEEEEEEEEEEEEEEK\n1\n23tyfgvubhiojpkl", colors.Text, new Rectangle(50, 100, 500, 300));
        }


        void DrawBackground(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(colors.Background), 0, 0, pictureBox1.Width, pictureBox1.Height);
        }

        void DrawFrame(PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(colors.Frame, 3), 0, 0, pictureBox1.Width, pictureBox1.Height);
        }

        void PaintStaticBefore(PaintEventArgs e)
        {
            DrawBackground(e);
            
        }

        void PaintStaticAfter(PaintEventArgs e)
        {
            DrawFrame(e);
        }

        void PaintDynamic(PaintEventArgs e)
        {
            DrawX(e);
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


        Point mouseCoords;

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

        void DrawText(PaintEventArgs e, string text, Color color, Rectangle area)
        {
            e.Graphics.DrawRectangle(new Pen(color), area);
            Point areaCenter = new Point(area.X+area.Width/2, area.Y+area.Height/2);

            text.Replace("\r", "");
            string[] line = text.Split('\n');
            int lineHeight = 25;
            for (int i = 0; i < line.Length; i++)
            {
                SizeF stringSize = e.Graphics.MeasureString(line[i], new Font("Microsoft Sans Serif", 14));
                int middleLineIndex = (int)Math.Round((double)line.Length / 2, MidpointRounding.AwayFromZero);
                int y = areaCenter.Y + (i + 1 - middleLineIndex) * lineHeight - lineHeight / 2;
                if (line.Length % 2 == 0)
                {
                    y -= lineHeight / 2;
                }

                e.Graphics.DrawString(line[i], new Font("Microsoft Sans Serif", 14), new SolidBrush(color), new Point((int)(areaCenter.X - stringSize.Width / 2), y));
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Applyrects();
            ResetMouseCoords();
            colors.ApplyColorScheme(Colors.ColorScheme.Default);
            pictureBox1.Refresh();
        }

        Rects rects = new Rects();
        void Applyrects()
        {
            pictureBox1.Location = new Point(rects.PictureBox1.X, rects.PictureBox1.Y);
            pictureBox1.Width = rects.PictureBox1.Width;
            pictureBox1.Height = rects.PictureBox1.Height;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            SetMouseCoords(e);
            pictureBox1.Refresh();
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            ResetMouseCoords();
            pictureBox1.Refresh();
        }
    }
}
