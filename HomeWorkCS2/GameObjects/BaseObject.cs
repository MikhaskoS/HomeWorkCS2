using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MkGame
{
    interface ICollision
    {
        bool Collision(ICollision obj);
        Rectangle Rect { get; }
    }

    abstract class BaseObject : ICollision
    {
        protected Point _pos;  // положение объеета
        protected Point _dir;  // направление
        protected Size _size;  // размер

        protected Point velosity; // скорость перемещения 
        public Point Velosity { get => velosity; set => velosity = value; }

        protected Rectangle rect;
        public Rectangle Rect { get => rect; set => rect = value; }

        public BaseObject(Point pos, Point dir, Size size)
        {
            _pos = pos;
            _dir = dir;
            _size = size;
            rect = new Rectangle(pos.X, pos.Y, size.Width, size.Height);
        }

        public abstract void Draw();
        public abstract void Update();
        public abstract void FrameUpdate();

        public bool Collision(ICollision obj)
        {
            return obj.Rect.IntersectsWith(this.Rect);
        }
    }
}
