using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Rects
    {
        public Rectangle PictureBox1 { get; set; }
        public Rectangle X { get; set; }

        public Rects()
        {
            Rectangle PictureBox1 = new Rectangle(0, 0, 1000, 650);
            Rectangle X = new Rectangle(PictureBox1.Width - 50, 0, 50, 35);

        }
    }
}
