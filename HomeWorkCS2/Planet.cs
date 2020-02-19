using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MkGame
{
    class Planet : BaseObject
    {
        private Image background;
        private readonly string directory;
        RectangleF rect;

        public Planet(Point pos, Point dir, Size size, string file) : base(pos, dir, size)
        {
            System.IO.DirectoryInfo df = new System.IO.DirectoryInfo("..\\..\\Images");
            directory = df.FullName;
            string filePath = Path.Combine(directory, file);

            background = Image.FromFile(filePath);
            rect = new RectangleF(pos.X, pos.Y, size.Width, size.Height);
        }

        public override void Draw()
        {
            Game.graphics.DrawImage(background, rect);
        }


        public override void Update()
        {
            if(rect.X > -(Size.Width + Game.Width / 2) && rect.X < Game.Width / 2)
            Draw();
        }

        public override void FrameUpdate()
        {
            rect.X = rect.X + velosity.X;
        }
    }
}
