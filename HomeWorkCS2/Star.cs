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
            if (Size.Width < 5) //крестик
            {
                Canvas.grfx.DrawLine(Pens.White, Pos.X - Size.Width, Pos.Y, Pos.X + Size.Width, Pos.Y);
                Canvas.grfx.DrawLine(Pens.White, Pos.X, Pos.Y - Size.Height, Pos.X, Pos.Y + Size.Height);
            }
            else // кружочек
            {
                Canvas.grfx.DrawEllipse(Pens.White, Pos.X, Pos.Y, Size.Width, Size.Height);
            }
        }

        public override void Update()
        {
            Draw();
        }
        public override void FrameUpdate()
        {
            Pos.X = Pos.X + velosity.X ;
            if (Pos.X < -Game.Width / 2) Pos.X = Game.Width / 2;
        }
    }

}
