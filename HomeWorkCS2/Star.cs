using System;
using System.Drawing;

namespace MkGame
{
    class Star : BaseObject
    {
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        { 
        }

        public override void Draw()
        {
            // отрисовка зависит от размера звезды
            if (_size.Width < 5) //крестик
            {
                CanvasForm.grfx.DrawLine(Pens.White, _pos.X - _size.Width, _pos.Y, _pos.X + _size.Width, _pos.Y);
                CanvasForm.grfx.DrawLine(Pens.White, _pos.X, _pos.Y - _size.Height, _pos.X, _pos.Y + _size.Height);
            }
            else // кружочек
            {
                CanvasForm.grfx.DrawEllipse(Pens.White, _pos.X, _pos.Y, _size.Width, _size.Height);
            }
        }

        public override void Update()
        {
            Draw();
        }
        public override void FrameUpdate()
        {
            _pos.X = _pos.X + velosity.X ;
            if (_pos.X < -Game.Width / 2) _pos.X = Game.Width / 2;
        }
    }

}
