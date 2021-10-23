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
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (true)
            {
                NewVertexName_keypress(e);
                NewVertexPaths_keypress(e);
            }
            pictureBox1.Refresh();
        }


        void Typing(KeyPressEventArgs e, Rectangle rect, string userInputKey)
        {
            if (MouseInsideRect(rect))
            {
                if (e.KeyChar == (char)8)
                {
                    string str = userInput[userInputKey];
                    if (str.Length > 0)
                    {
                        userInput[userInputKey] = str.Substring(0, str.Length - 1);
                    }
                }
                else if (Char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == ',')
                {
                    userInput[userInputKey] += e.KeyChar;
                }
            }
        }


        void NewVertexName_keypress(KeyPressEventArgs e)
        {
            Typing(e, rects.NewVertexName, strings.NewVertexName);
        }


        void NewVertexPaths_keypress(KeyPressEventArgs e)
        {
            Typing(e, rects.NewVertexPaths, strings.NewVertexPaths);
        }
    }
}
