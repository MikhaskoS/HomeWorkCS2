using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MkGame
{
    class Bullet : BaseObject
    {
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            velosity = new Point(30, 0);
            Rect = new Rectangle(pos.X, pos.Y, size.Width, size.Height);
        }

        public override void Draw() => 
            CanvasForm.Grfx.DrawRectangle(Pens.Yellow, _pos.X, _pos.Y, _size.Width, _size.Height);

        public override void FrameUpdate()
        {
            _pos.X += velosity.X;
            rect.X = _pos.X;
            rect.Y = _pos.Y;
        }

        public override void Update() => Draw();
    }
}
