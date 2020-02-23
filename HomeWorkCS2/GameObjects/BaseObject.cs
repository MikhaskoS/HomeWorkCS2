using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MkGame
{
    abstract class BaseObject
    {
        protected Point _pos;  // положение объеета
        protected Point _dir;  // направление
        protected Size _size;  // размер

        protected Point velosity; // скорость перемещения 
        public Point Velosity { get => velosity; set => velosity = value; }

        public BaseObject(Point pos, Point dir, Size size)
        {
            _pos = pos;
            _dir = dir;
            _size = size;
        }

        public abstract void Draw();
        public abstract void Update();
        public abstract void FrameUpdate();
    }
}
