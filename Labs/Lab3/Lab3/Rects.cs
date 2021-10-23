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
            MenuBar = new Rectangle(PictureBox1.X, PictureBox1.Y, PictureBox1.Width, 35);
            X = new Rectangle(MenuBar.Width - 50, MenuBar.Y, 50, 35);
            Minimize = new Rectangle(MenuBar.Width - X.Width - 50, MenuBar.Y, 50, MenuBar.Height);
            Open = new Rectangle(MenuBar.X, MenuBar.Y, 150, MenuBar.Height);
            RandomizeGraph = new Rectangle(Open.Width, MenuBar.Y, 150, MenuBar.Height);
            AddVertex = new Rectangle(RandomizeGraph.X + RandomizeGraph.Width, MenuBar.Y, 150, MenuBar.Height);
            NewVertexName = new Rectangle(AddVertex.X + AddVertex.Width, MenuBar.Y, 150, MenuBar.Height);
            NewVertexPaths = new Rectangle(NewVertexName.X + NewVertexName.Width, MenuBar.Y, 150, MenuBar.Height);
            GraphArea = new Rectangle(PictureBox1.X, MenuBar.Y + MenuBar.Height, PictureBox1.Width, PictureBox1.Height - MenuBar.Height);
            Vertex = new Rectangle(0, 0, 10, 10);
            VertexArea = new Rectangle(0, 0, 30, 30);
        }
    }
}
