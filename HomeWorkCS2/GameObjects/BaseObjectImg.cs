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

        public Image Image { get => image; set => image = value; }
       
        public BaseObjectImg(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public BaseObjectImg(Point pos, Point dir, Size size, string file) : base(pos, dir, size)
        {
            image = Utility.GetImage(file);
        }
    }
}
