using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace MkGame
{
    static class Game
    {
        public static int Width { get; set; }
        public static int Height { get; set; }

        public static BaseObject[] obj;
        public static Planet[] planets;
        public static Asteroid[] asteroids;
        public static Background background;

        static Game()
        {
        }

        public static void Load()
        {
            Random rnd = new Random();

            background = new Background();

            obj = new BaseObject[30];
            for (int i = 0; i < obj.Length; i++)
            {
                int sizeStar = rnd.Next(1, 6);

                obj[i] = new Star(
                    new Point(rnd.Next(-Width / 2, Width / 2), rnd.Next(-Height / 2, Height / 2)),
                    new Point(0, 0), new Size(sizeStar, sizeStar))
                { Velosity = new Point(-rnd.Next(1, 3), 0)};
            }

            planets = new Planet[] {
                new Planet( new Point(0, -700), new Point(0,0), new Size(1024, 1024), "Sun.png")
                { Velosity = new Point(-1, 0)},
                new Planet( new Point(Width, 0), new Point(0,0), new Size(640, 640), "Planet.png")
                { Velosity = new Point(-2, 0)}};

            asteroids = new Asteroid[10];
            for (int i = 0; i < asteroids.Length; i++)
            {
                int r = rnd.Next(25, 50);
                asteroids[i] = new Asteroid(
                    new Point(rnd.Next(512, 1400), rnd.Next(-Height / 2, Height / 2)),
                  new Point(0, 0), new Size(r, r), "asteroid.png")
                { Velosity = new Point(-4, 0) };
            }

        }

        public static void Init(int width, int height)
        {
            Width = width;
            Height = height;
            Load();
        }

        // обновление кадра за фиксированное время
        public static void FrameUpdate()
        {
            foreach (BaseObject ob in obj)
                ob.FrameUpdate();
            foreach (Planet pl in planets)
                pl.FrameUpdate();
            for (var i = 0; i < asteroids.Length; i++)
            {
                if (asteroids[i] == null) continue;
                asteroids[i].FrameUpdate();
            }
        }

        // перерисовка экрана
        public static void Update(int width, int height)
        {
            Width = width;
            Height = height;

            background.Draw(CanvasForm.Grfx);

            foreach (BaseObject ob in obj)
                ob.Update();
            foreach (Planet pl in planets)
                pl.Update();
            foreach (Asteroid a in asteroids)
            {
                if (a == null) continue;
                a.Update();
            }

            Application.DoEvents();
        }
    }
}
