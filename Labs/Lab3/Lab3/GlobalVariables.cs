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
        DataTable dataTable;
        Colors colors;
        Strings strings;
        Rects rects;
        Point mouseCoords;
        bool movingWindow;
        private bool MouseIsDown { get; set; }
        private Point mouseDownCoords { get; set; }


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
