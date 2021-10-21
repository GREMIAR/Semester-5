using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Colors
    {
        public enum ColorScheme { Default, Debug };
        public ColorScheme Theme { get; private set; }
        public Color Background { get; private set; }
        public Color Frame { get; private set; }
        public Color Edge { get; private set; }
        public Color Vertex { get; private set; }
        public Color Text { get; private set; }
        public Color Select { get; private set; }


        private void SetColors(Color backgroundColor, Color frameColor, Color edgeColor, Color vertexColor, Color textColor, Color select)
        {
            this.Background = backgroundColor;
            this.Frame = frameColor;
            this.Edge = edgeColor;
            this.Vertex = vertexColor;
            this.Text = textColor;
            this.Select = textColor;
        }

        public void ApplyColorScheme(ColorScheme theme)
        {
            this.Theme = theme;
            if (Theme == ColorScheme.Default)
            {
                SetColors(Color.Black, Color.Gray, Color.White, Color.White, Color.Coral, Color.DarkGray);
            }
        }
    }
}
