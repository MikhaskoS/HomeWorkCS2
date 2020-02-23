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
        private Image _image;
        RectangleF rect;

        public Planet(Point pos, Point dir, Size size, string file) : base(pos, dir, size)
        {
            _image = Utility.GetImage(file);
            rect = new RectangleF(pos.X, pos.Y, size.Width, size.Height);
        }

        public override void Draw()
        {
            CanvasForm.Grfx.DrawImage(_image, rect);
        }

        public override void Update()
        {
            if(rect.X > -(_size.Width + Game.Width / 2) && rect.X < Game.Width / 2)
            Draw();
        }

        public override void FrameUpdate()
        {
            rect.X = rect.X + velosity.X;
        }
    }
}
