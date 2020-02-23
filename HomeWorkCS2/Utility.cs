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
    }
}
