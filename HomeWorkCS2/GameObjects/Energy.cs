﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MkGame
{
    class EnergyBox : BaseObjectImg
    {
        public EnergyBox(Point pos, Point dir, Size size, string file) : base(pos, dir, size)
        {
            image = Utility.GetImage(file);
            rect = new Rectangle(pos.X, pos.Y, size.Width, size.Height);
        }

        public override void Draw() => CanvasForm.Grfx.DrawImage(image, rect);

        public override void FrameUpdate()
        {
            rect.X += velosity.X;
            if (rect.X < -Game.Width / 2)
                rect.X = Game.Width / 2;
        }

        public override void Update() => Draw();
    }
}
