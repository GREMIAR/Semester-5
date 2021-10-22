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
        public Rectangle Minimize { get; set; }
        public Rectangle Open { get; set; }

        public Rects()
        {
            PictureBox1 = new Rectangle(0, 0, 1000, 650);
            X = new Rectangle(PictureBox1.Width - 50, 0, 50, 35);
            Minimize = new Rectangle(PictureBox1.Width - 100, 0, 50, 35);
            Open = new Rectangle(0, 0, 150, 35);
            
        }
    }
}
