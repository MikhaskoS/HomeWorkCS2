using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MkGame
{
    class Ship:BaseObjectImg
    {
        private int _energy = 100;
        private int _score = 0;
        public int Energy { get => _energy; } 
        public int Score { get => _score; }

        public Ship(Point pos, Point dir, Size size, string file) : base(pos, dir, size)
        {
            image = Utility.GetImage(file);
            rect = new Rectangle(pos.X, pos.Y, size.Width, size.Height);
        }

        public static event Action DieEvent;
        public void EnergyLow(int n)
        {
            _energy -= n;
        }
        public void ChangeScore(int score)
        {
            _score += score;
        }

        public override void Draw() => CanvasForm.Grfx.DrawImage(image, rect);

        public override void Update()
        {
            Draw();
        }

        public override void FrameUpdate()
        {
        }
        public void Up()
        {
            if (_pos.Y > -Game.Height / 2) 
                _pos.Y -= _dir.Y;
            rect.Y = _pos.Y;
        }
        public void Down()
        {
            if (_pos.Y < Game.Height/2 - rect.Height) 
                _pos.Y += _dir.Y;
            rect.Y = _pos.Y;
        }
        public void Die()
        {
            DieEvent?.Invoke();
        }
    }
}
