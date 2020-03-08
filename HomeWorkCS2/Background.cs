using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MkGame
{
    class Background
    {
        private readonly  Image background;
        int _xPos;
        int _yPos;
        int _width;
        int _height;

        public int XPos { get => _xPos; set => _xPos = value; }
        public int YPos { get => _yPos; set => _yPos = value; }
        public int Width { get => _width; set => _width = value; }
        public int Height { get => _height; set => _height = value; }

        public Background(int xPos = -512, int yPos = -612, int width = 850, int height = 850)
        {
            XPos = xPos;
            YPos = yPos;
            Width = width;
            Height = height;

            background = Utility.GetImage( "PurpleNebula.jpg");
        }

        public void Draw(Graphics grfx)
        {
            grfx?.DrawImage(background, new Point(XPos,YPos));
        }
    }
}
