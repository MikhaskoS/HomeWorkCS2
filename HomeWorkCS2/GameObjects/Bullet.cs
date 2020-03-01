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
        private bool _visible;
        public bool Visible { get => _visible; set => _visible = value; }
        
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            velosity = new Point(30, 0);
            Rect = new Rectangle(pos.X, pos.Y, size.Width, size.Height);
            _visible = false;
        }

        public void SetPosition(Point value)
        { _pos = value; }


        public override void Draw()
        {
            if (!_visible) return;
            CanvasForm.Grfx.DrawRectangle(Pens.Yellow, _pos.X, _pos.Y, _size.Width, _size.Height);
        }

        public override void FrameUpdate()
        {
            if (!_visible) return;
            _pos.X += velosity.X;
            rect.X = _pos.X;
            rect.Y = _pos.Y;

            if (_pos.X > Game.Width / 2)
                _visible = false;
        }

        public override void Update() => Draw();
    }
}
