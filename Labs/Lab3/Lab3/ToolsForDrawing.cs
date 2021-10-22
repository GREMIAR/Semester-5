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
        void DrawBtn(PaintEventArgs e, Rectangle x, bool available)
        {
            if (available)
            {
                if (MouseInsideRect(x))
                {
                    e.Graphics.FillRectangle(new SolidBrush(colors.Select), x);
                }
                else
                {
                    e.Graphics.FillRectangle(new SolidBrush(colors.Background), x);
                }
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(colors.Unavailable), x);
            }
        }

        void DrawText(PaintEventArgs e, string text, Color color, Rectangle area)
        {
            Point areaCenter = new Point(area.X + area.Width / 2, area.Y + area.Height / 2);
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



        void DrawTextBox(PaintEventArgs e, Rectangle x, bool available)
        {
            if (available)
            {
                if (MouseInsideRect(x))
                {
                    e.Graphics.FillRectangle(new SolidBrush(colors.Select), x);
                }
                else
                {
                    e.Graphics.FillRectangle(new SolidBrush(colors.Background), x);
                }
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(colors.Unavailable), x);
            }
            e.Graphics.DrawLine(new Pen(colors.Text), new Point(x.X + x.Width / 7, x.Y + rects.MenuBar.Height), new Point(x.X + x.Width * 6 / 7));
        }
    }
}
