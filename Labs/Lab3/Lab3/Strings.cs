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


        private void SetStrings(string btnOpen)
        {
            this.BtnOpen = btnOpen;
        }

        public void ApplyLanguage(Language lang)
        {
            this.Lang = lang;
            if (Lang == Language.Russian)
            {
                SetStrings("Открыть");
            }
            else if (Lang == Language.English)
            {
                SetStrings("Open");
            }
        }
    }
}
