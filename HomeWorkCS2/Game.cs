using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace MkGame
{
    static class Game
    {
        public static Graphics graphics;

        public static int Width { get; set; }
        public static int Height { get; set; }

        public static BaseObject[] _obj;
        public static Planet[] _planets;
        public static Background background;

        static Game()
        {
        }

        public static void Load()
        {
            Random rnd = new Random();

            background = new Background();

            _obj = new BaseObject[30];
            for (int i = 0; i < _obj.Length; i++)
            {
                int sizeStar = rnd.Next(1, 6);

                _obj[i] = new Star(
                    new Point(rnd.Next(-Width / 2, Width / 2), rnd.Next(-Height / 2, Height / 2)),
                    new Point(0, 0), new Size(sizeStar, sizeStar));
                _obj[i].Velosity = new Point(-rnd.Next(1, 3), 0);
            }

            _planets = new Planet[] {
                new Planet( new Point(0, -700), new Point(0,0), new Size(1024, 1024), "Sun.png"),
                new Planet( new Point(Width, 0), new Point(0,0), new Size(640, 640), "Planet.png") };
            _planets[0].Velosity = new Point(-1, 0);
            _planets[1].Velosity = new Point(-2, 0);
        }

        public static void Init(int width, int height)
        {
            Width = width;
            Height = height;
            Load();

            Timer timer = new Timer { Interval = 60 };
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            FrameUpdate();
        }

        // обновление кадра за фиксированное время
        public static void FrameUpdate()
        {
            foreach (BaseObject ob in _obj)
                ob.FrameUpdate();
            foreach (Planet pl in _planets)
                pl.FrameUpdate();
        }

        // перерисовка экрана
        public static void Update(Graphics grfx, int width, int height)
        {
            graphics = grfx;

            Width = width;
            Height = height;

            background.Draw(grfx);

            foreach (BaseObject ob in _obj)
                ob.Update();
            foreach (Planet pl in _planets)
                pl.Update();

            Application.DoEvents();
        }
    }
}
