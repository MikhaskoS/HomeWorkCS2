using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MkGame
{
    abstract class BaseObjectImg : BaseObject
    {
        protected Image image;
        protected Rectangle rect;

        public Image Image { get => image; set => image = value; }
        public Rectangle Rect { get => rect; set => rect = value; }

        public BaseObjectImg(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public BaseObjectImg(Point pos, Point dir, Size size, string file) : base(pos, dir, size)
        {
            image = Utility.GetImage(file);
            rect = new Rectangle(pos.X, pos.Y, size.Width, size.Height);
        }
    }
}
