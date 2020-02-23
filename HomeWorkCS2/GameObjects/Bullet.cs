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
        private Rectangle _rect;
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            velosity = new Point(6, 0);
            _rect = new Rectangle(pos.X, pos.Y, size.Width, size.Height);
        }

        public Rectangle Rect { get => _rect; set => _rect = value; }

        public override void Draw()
        {
            CanvasForm.Grfx.DrawRectangle(Pens.Yellow, _pos.X, _pos.Y, _size.Width, _size.Height);
        }

        public override void FrameUpdate()
        {
            _pos.X += velosity.X;
            _rect.X = _pos.X;
        }

        public override void Update()
        {
            Draw();
        }
    }
}
