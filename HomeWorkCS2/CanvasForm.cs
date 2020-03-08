using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MkGame
{
    public partial class CanvasForm : Form
    {
        public static Timer timer;

        private readonly bool _closing = false;
        private bool _startGame = false;
        private static Graphics _grfx;
        public static Graphics Grfx { get => _grfx; }

        public CanvasForm()
        {
            // Здесь устанавливается двойной буффер!
            this.SetStyle(ControlStyles.DoubleBuffer |
                 ControlStyles.UserPaint |
                 ControlStyles.AllPaintingInWmPaint,
                 true);

            InitializeComponent();

            Game.Init(this.ClientSize.Width, this.ClientSize.Height);
            SplashScreen.Init(this.ClientSize.Width, this.ClientSize.Height);

            this.KeyDown += CanvasForm_KeyDown;
            this.Disposed += CanvasForm_Disposed;
            _startGame = false;


            timer = new Timer { Interval = 60 };
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void CanvasForm_Disposed(object sender, EventArgs e)
        {
            Game.logger.Close();
        }

        // Контролируемая частота будет использованая для математических расчетов
        private  void Timer_Tick(object sender, EventArgs e)
        {
            if (_startGame)
                Game.FrameUpdate();
            else
                SplashScreen.FrameUpdate();
        }

        // Paint выполняет перерисовку экрана с непредсказуемой частотой 
        // Здесь размещена пассивная перерисовка, делающая движение плавным
        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            if (this.IsDisposed) return;
            if (_closing) return;

            // начало координат в центре экрана
            _grfx = e.Graphics;
            _grfx.TranslateTransform(this.ClientSize.Width / 2, this.ClientSize.Height / 2);
            _grfx.ScaleTransform(1, 1);

            if (_startGame)
                Game.Update(this.ClientSize.Width, this.ClientSize.Height);
            else
             SplashScreen.Update(this.ClientSize.Width, this.ClientSize.Height);


            Application.DoEvents();
            this.Invalidate();
        }


        private void CanvasForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (!_startGame) _startGame = true;

            if (Game.GameFail) return;
            Game.KeyDown(sender, e);
        }        
    }

}
