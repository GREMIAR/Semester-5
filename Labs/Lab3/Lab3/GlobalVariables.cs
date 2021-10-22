using System.IO;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System;
using System.Collections.Generic;

namespace Lab3
{
    public partial class Form1
    {
        DataTable dataTable;
        Colors colors;
        Strings strings;
        Rects rects;
        Random rnd;
        List<Point> vertices;
        Point mouseCoords { get; set; }
        bool movingWindow { get; set; }
        bool MouseIsDown { get; set; }
        Point mouseDownCoords { get; set; }
        bool DataTableIsFilled { get; set; }


        void SetStartValues()
        {
            SetFirstStartValues();
            SetSecondStartValues();
        }

        void SetFirstStartValues()
        {
            colors = new Colors();
            strings = new Strings();
            rects = new Rects();
            vertices = new List<Point>();
            rnd = new Random();
        }

        void SetSecondStartValues()
        {
            SetLocAndSizeOfPB();
            ResetMouseCoords();
            colors.ApplyColorScheme(Colors.ColorScheme.Default);
            strings.ApplyLanguage(Strings.Language.Russian);
        }
    }
}
