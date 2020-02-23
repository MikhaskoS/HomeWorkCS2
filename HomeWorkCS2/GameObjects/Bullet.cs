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
            velosity = new Point(10, 0);
            Rect = new Rectangle(pos.X, pos.Y, size.Width, size.Height);
        }

        public override void Draw() => 
            CanvasForm.Grfx.DrawRectangle(Pens.Yellow, _pos.X, _pos.Y, _size.Width, _size.Height);

        public override void FrameUpdate()
        {
            if (_pos.X > Game.Width / 2)
            {
                Random rnd = new Random();
                _pos.X = -Game.Width / 2;
                _pos.Y = rnd.Next(-Game.Height / 2, Game.Height / 2);
            }

            _pos.X += velosity.X;
            rect.X = _pos.X;
            rect.Y = _pos.Y;
        }

        public override void Update() => Draw();
    }
}
