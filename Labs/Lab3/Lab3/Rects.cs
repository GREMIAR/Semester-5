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
        public Rectangle MenuBar { get; set; }
        public Rectangle X { get; set; }
        public Rectangle Minimize { get; set; }
        public Rectangle Open { get; set; }
        public Rectangle RandomizeGraph { get; set; }
        public Rectangle GraphArea { get; set; }
        public Rectangle Vertex { get; set; }
        public Rectangle VertexArea { get; set; }
        public Rectangle AddVertex { get; set; }
        public Rectangle NewVertexName { get; set; }
        public Rectangle NewVertexPaths { get; set; }

        public Rects()
        {
            PictureBox1 = new Rectangle(0, 0, 1000, 650);
            MenuBar = new Rectangle(0, 0, PictureBox1.Width, 35);
            X = new Rectangle(PictureBox1.Width - 50, 0, 50, 35);
            Minimize = new Rectangle(PictureBox1.Width - X.Width - 50, 0, 50, MenuBar.Height);
            Open = new Rectangle(0, 0, 150, MenuBar.Height);
            RandomizeGraph = new Rectangle(Open.Width, 0, 300, MenuBar.Height);
            AddVertex = new Rectangle(RandomizeGraph.X + RandomizeGraph.Width, 0, 150, MenuBar.Height);
            NewVertexName = new Rectangle(RandomizeGraph.X + RandomizeGraph.Width, 0, 150, MenuBar.Height);
            GraphArea = new Rectangle(0, MenuBar.Height, PictureBox1.Width, PictureBox1.Height - MenuBar.Height);
            Vertex = new Rectangle(0, 0, 10, 10);
            VertexArea = new Rectangle(0, 0, 30, 30);
        }
    }
}
