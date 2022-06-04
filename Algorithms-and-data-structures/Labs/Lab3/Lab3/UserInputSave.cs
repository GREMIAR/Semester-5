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
        void SetUserInput()
        {
            userInput.Add(strings.NewVertexName, strings.NewVertexName);
            userInput.Add(strings.NewVertexPaths, strings.NewVertexPaths);
        }
    }
}
