using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Strings
    {
        public enum Language { Russian, English };
        public Language Lang { get; private set; }
        public string BtnOpen { get; private set; }
        public string BtnRandomizeGraph { get; private set; }
        public string DeleteVertex { get; private set; }
        public string BtnAddVertex { get; private set; }
        public string NewVertexName { get; private set; }
        public string NewVertexPaths { get; private set; }


        private void SetStrings(string btnOpen, string btnRandomizeGraph, string deleteVertex, string btnAddVertex, string newVertexName, string newVertexPaths)
        {
            this.BtnOpen = btnOpen;
            this.BtnRandomizeGraph = btnRandomizeGraph;
            this.DeleteVertex = deleteVertex;
            this.BtnAddVertex = btnAddVertex;
            this.NewVertexName = newVertexName;
            this.NewVertexPaths = newVertexPaths;
        }

        public void ApplyLanguage(Language lang)
        {
            this.Lang = lang;
            if (Lang == Language.Russian)
            {
                SetStrings("Открыть", "Случайно", "Удалить", "Добавить", "<Имя>mmmmmmmmmmmmmmmmmmmmfssg", "<Путь1,Путь2>");
            }
            else if (Lang == Language.English)
            {
                SetStrings("Open", "Randomize", "Remove", "Add", "<Name>", "<Path1,Path2>");
            }
        }
    }
}
