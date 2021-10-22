using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class ReadExcelFile
    {
        public void ReadExcel(string fileName)
        {
            string[] fullFile = File.ReadAllLines(fileName);
            matrix = Matrix(fullFile[0].Split(' '));

            foreach (string str in NewFile)
            {
                Console.WriteLine(str);//тут твоё действие. В данном случае - вывести строку.
            }
            Console.ReadKey(true);
        }
    }
}
