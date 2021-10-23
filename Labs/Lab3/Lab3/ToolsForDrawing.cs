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
                SizeF stringSize = e.Graphics.MeasureString(line[i], ourFont);
                int middleLineIndex = (int)Math.Round((double)line.Length / 2, MidpointRounding.AwayFromZero);
                int y = areaCenter.Y + (i + 1 - middleLineIndex) * lineHeight - lineHeight / 2;
                if (line.Length % 2 == 0)
                {
                    y -= lineHeight / 2;
                }
                e.Graphics.DrawString(line[i], ourFont, new SolidBrush(color), new Point((int)(areaCenter.X - stringSize.Width / 2), y));
            }
        }

        void DrawTextInTextBox(PaintEventArgs e, string text, Color color, Rectangle area)
        {
            bool fitsCompletely = true;
            if (MouseInsideRect(area))
            {
                text.Replace("\r", "");
                text = text.Split('\n')[0];

                int fits = CharsFitInRect(e, text, area, false);
                if (fits > 0)
                {
                    fitsCompletely = !(fits < text.Length);
                    if (!fitsCompletely)
                    {
                        text = text.Substring(fits + 1, text.Length - fits - 1);
                    }
                }
            }
            else
            {
                text.Replace("\r", "");
                text = text.Split('\n')[0];

                int fits = CharsFitInRect(e, text, area, true);
                if (fits>0)
                {
                    fitsCompletely = !(fits < text.Length);
                    text = text.Substring(0, fits);
                }
            }
            if (!fitsCompletely)
            {
                text += "...";
            }
            SizeF stringSize = e.Graphics.MeasureString(text, ourFont);
            e.Graphics.DrawString(text, ourFont, new SolidBrush(color), new Point(area.X + area.Width / 7, area.Y + area.Height / 2 - (int)stringSize.Height / 2));
        }

        int CharsFitInRect(PaintEventArgs e, string text, Rectangle rect, bool startFromZero)
        {
            SizeF stringSize = e.Graphics.MeasureString(text, ourFont);
            if (stringSize.Width <= rect.Width * 5 / 7)
            {
                return text.Length;
            }
            if (startFromZero)
            {
                for (int i = 0; i < text.Length; i++)
                {
                    string newText = text.Substring(0, i) + "...";
                    stringSize = e.Graphics.MeasureString(newText, ourFont);
                    if (stringSize.Width > rect.Width * 5 / 7)
                    {
                        return i;
                    }
                }
            }
            else
            {
                for (int i = text.Length; i >= 0; i--)
                {
                    string newText = text.Substring(i, text.Length - i) + "...";
                    stringSize = e.Graphics.MeasureString(newText, ourFont);
                    if (stringSize.Width > rect.Width * 5 / 7)
                    {
                        return i;
                    }
                }
            }
                return -2;
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
            e.Graphics.DrawLine(new Pen(colors.Text), new Point(x.X + x.Width / 7, x.Y + rects.MenuBar.Height * 6 / 7), new Point(x.X + x.Width * 6 / 7, x.Y + rects.MenuBar.Height * 6 / 7));
        }
    }
}
