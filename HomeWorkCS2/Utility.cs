using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MkGame
{
    public static class Utility
    {
        public static DirectoryInfo ImageDirectory { get; set; } =
            new System.IO.DirectoryInfo("..\\..\\Images");

        public static Image GetImage(string fileName)
        {
            string directory = Utility.ImageDirectory.FullName;
            string filePath = Path.Combine(directory, fileName);

            return Image.FromFile(filePath);
        }

        public static bool Flicker(int f1, int f2, ref int timer)
        {
            timer++;
            if (timer < f1)
                return false;
            else if (timer < 2 * f2)
                return true;
            else
                timer = 0;

            return false;
        }
        
    }
}
