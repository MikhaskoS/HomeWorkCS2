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
        protected Point Pos;  // положение объеета
        protected Point Dir;  // направление
        protected Size Size;  // размер

        protected Point velosity; // скорость перемещения 
        public Point Velosity { get => velosity; set => velosity = value; }

        public BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }


        abstract public void Draw();
        abstract public void Update();
        abstract public void FrameUpdate();

    }
}
