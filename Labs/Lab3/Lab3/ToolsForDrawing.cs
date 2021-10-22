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
        void DrawBtn(PaintEventArgs e, Rectangle x)
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
    }
}
