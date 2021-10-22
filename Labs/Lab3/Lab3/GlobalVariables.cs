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
        Colors colors = new Colors();
        Point mouseCoords;
        Rects rects;
        bool movingWindow;
        private bool MouseIsDown { get; set; }
        private Point mouseDownCoords { get; set; }

    }
}
