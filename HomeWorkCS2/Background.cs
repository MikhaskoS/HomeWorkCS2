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
        private  Image background;
        private readonly string directory;
        RectangleF rect;

        public Background()
        {
            System.IO.DirectoryInfo df = new System.IO.DirectoryInfo("..\\..\\Images");
            directory = df.FullName;
            string filePath = Path.Combine(directory, "PurpleNebula.jpg");
            
            background = Image.FromFile(filePath);
            rect = new RectangleF(-800.0F, -600.0F, 850.0F, 850.0F);
        }

        public void Draw(Graphics grfx)
        {
            
            grfx.DrawImage(background, new Point(-512,-612));
        }
    }
}
