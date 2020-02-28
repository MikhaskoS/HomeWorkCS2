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
        public static Background background = new Background();

        private static Ship _ship = new Ship(new Point(-400, 0),
            new Point(5, 5), new Size(80, 60), "Ship.png");

        public static Bullet _bullet;
        public static Energy _energy;

        public static GameLogger logger;

        static bool _gameFail = false;
        public static bool GameFail { get => _gameFail; }

        #region Events
        public static event Action InitGameEvent;
        public static event Action LoadGameEvent;
        public static event Action GameOverEvent;
        public static event Action<KeyEventArgs> KeyDownEvent;
        #endregion

        static Game()
        {
           
        }

        public static void Load()
        {
            Random rnd = new Random();

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
                    new Point(rnd.Next(256, 1400), rnd.Next(-Height / 2 + 50, Height / 2 -50 )),
                  new Point(0, 0), new Size(r, r), "asteroid.png")
                { Velosity = new Point(-4, 0) };
            }
            _energy = new Energy(
                    new Point(rnd.Next(0, Width/4), rnd.Next(-Height / 4 , Height / 4 )),
                  new Point(0, 0), new Size(20, 40), "Energy.png")
            { Velosity = new Point(-4, 0) };

            LoadGameEvent?.Invoke();
        }

        public static void Init(int width, int height)
        {
            logger = new GameLogger();

            if (width <= 0 || height <= 0 || width > 2000 || height > 2000)
                throw new GameException("Неверные размеры экрана!", new ArgumentOutOfRangeException());

            Width = width;
            Height = height;
            
            Load();

            Ship.DieEvent += GameOver;

            InitGameEvent?.Invoke();
        }

        // обновление кадра за фиксированное время
        public static void FrameUpdate()
        {
            foreach (BaseObject ob in obj)
                ob?.FrameUpdate();
            foreach (Planet pl in planets)
                pl?.FrameUpdate();
            for (var i = 0; i < asteroids.Length; i++)
            {
                if (asteroids[i] == null) continue;
                asteroids[i].FrameUpdate();

                if (_bullet != null && asteroids[i].Collision(_bullet)) // произошло столкновение
                {
                    System.Media.SystemSounds.Hand.Play();
                    asteroids[i] = null;
                    _bullet = null;
                    _ship?.ChangeScore(50);
                    continue;
                }

                if (_ship != null)
                {
                    // столкновение корабля с астероидом
                    if (!_ship.Collision(asteroids[i])) continue;
                    var rnd = new Random();
                    _ship?.EnergyLow(rnd.Next(1, 10));

                    System.Media.SystemSounds.Asterisk.Play();
                    if (_ship.Energy <= 0)
                    {
                        _ship?.Die();
                        logger.LogInformation("Корабль уничтожен!");
                    }
                }
            }
            if (_energy != null)
            {
                if (_ship.Collision(_energy))
                {
                    _ship?.EnergyLow(-50);
                    _energy = null;
                }
            }

            _bullet?.FrameUpdate();
            _energy?.FrameUpdate();
        }

        internal static void KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Space:
                        _bullet = new Bullet(new Point(_ship.Rect.X + 80, _ship.Rect.Y + 30), 
                            new Point(0, 0), new Size(20, 2));
                    break;
                case Keys.W:
                    _ship?.Up();
                    break;
                case Keys.S:
                    _ship?.Down();
                    break;
            }

            KeyDownEvent?.Invoke(e);
        }

        // перерисовка экрана
        public static void Update(int width, int height)
        {
            Width = width;
            Height = height;

            background?.Draw(CanvasForm.Grfx);

            foreach (BaseObject ob in obj)
                ob?.Update();
            foreach (Planet pl in planets)
                pl?.Update();
            foreach (Asteroid a in asteroids)
            {
                a?.Update();
            }

            _bullet?.Update();
            _ship?.Update();
            _energy?.Update();

            if (_ship != null)
            {
                CanvasForm.Grfx.DrawString("Energy: " + _ship.Energy,
                new Font(FontFamily.GenericSansSerif,
                15, FontStyle.Italic), Brushes.White, -Width / 2 + 10, -Height / 2 + 20);
                CanvasForm.Grfx.DrawString(" Score: " + _ship.Score,
                new Font(FontFamily.GenericSansSerif,
                15, FontStyle.Italic), Brushes.White, -Width / 2 + 10, -Height / 2 + 50);
            }
            else
                CanvasForm.Grfx.DrawString("The End", new Font(FontFamily.GenericSansSerif,
                    60, FontStyle.Underline), Brushes.White, -180, -50);
        }

        private static void GameOver()
        {
            CanvasForm.timer.Stop();
            _ship = null;
            _gameFail = true;
            GameOverEvent?.Invoke();
        }
    }
}
