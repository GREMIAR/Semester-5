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
        Matrix matrix;
        Colors colors;
        Strings strings;
        Rects rects;
        Random rnd;
        Font ourFont { get; set; }
        Point mouseCoords { get; set; }
        bool movingWindow { get; set; }
        bool MouseIsDown { get; set; }
        Point mouseDownCoords { get; set; }
        Dictionary<string, string> userInput;

        void SetStartValues()
        {
            SetFirstStartValues();
            SetSecondStartValues();
        }

        void SetFirstStartValues()
        {
            ourFont = new Font("Comic Sans MS", 14);
            colors = new Colors();
            strings = new Strings();
            rects = new Rects();
            rnd = new Random();
            userInput = new Dictionary<string, string>();
        }

        void SetSecondStartValues()
        {
            SetLocAndSizeOfPB();
            ResetMouseCoords();
            colors.ApplyColorScheme(Colors.ColorScheme.Default);
            strings.ApplyLanguage(Strings.Language.Russian);
            SetUserInput();
        }
    }
}
