using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MkGame
{
    class SplashScreen
    {
        public static Background background;

        public static int Width { get; set; }
        public static int Height { get; set; }

        public static BaseObject[] gameObjects;
        private static int _timer = 0;
        private static bool _view = true;

        public SplashScreen()
        {
        }
        public static void Load()
        {
            Random rnd = new Random();
            background = new Background();
            gameObjects = new BaseObject[30];
            for (int i = 0; i < gameObjects.Length; i++)
            {
                int sizeStar = rnd.Next(1, 6);

                gameObjects[i] = new Star(
                    new Point(rnd.Next(-Width / 2, Width / 2), rnd.Next(-Height / 2, Height / 2)),
                    new Point(0, 0), new Size(sizeStar, sizeStar))
                { Velosity = new Point(-rnd.Next(1, 3), 0)};
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
            foreach (BaseObject ob in gameObjects)
                ob?.FrameUpdate();

            _view = Utility.Flicker(5, 5, ref _timer);
        }

        // перерисовка экрана
        public static void Update( int width, int height)
        {
            Width = width;
            Height = height;

            background?.Draw(CanvasForm.Grfx);

            CanvasForm.Grfx.DrawString("Asteroid", new Font(FontFamily.GenericSansSerif,
                60, FontStyle.Underline), Brushes.Violet, -180, -150);
            CanvasForm.Grfx.DrawString("W/S - движение корабля", new Font(FontFamily.GenericSansSerif,
                15, FontStyle.Italic), Brushes.Violet, -180, 30);
            CanvasForm.Grfx.DrawString("Space - выстрел", new Font(FontFamily.GenericSansSerif,
             15, FontStyle.Italic), Brushes.Violet, -180, 60);

            if(_view)
                CanvasForm.Grfx.DrawString("Press any key...", new Font(FontFamily.GenericSansSerif,
                    15, FontStyle.Italic), Brushes.Yellow, -120, 250);

            foreach (BaseObject ob in gameObjects)
                ob?.Update();
        }
    }
}
