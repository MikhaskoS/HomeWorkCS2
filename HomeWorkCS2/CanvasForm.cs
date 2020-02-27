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

        private bool _closing = false;
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

            this.FormClosing += Canvas_FormClosing;
            this.KeyDown += CanvasForm_KeyDown;
            _startGame = false;


            timer = new Timer { Interval = 60 };
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Canvas_FormClosing(object sender, FormClosingEventArgs e)
        {
            _closing = true;
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
            if (_closing) return;

            // начало координат в центре экрана
            _grfx = e.Graphics;
            _grfx.TranslateTransform(this.ClientSize.Width / 2, this.ClientSize.Height / 2);
            _grfx.ScaleTransform(1, 1);

            if (_startGame)
                Game.Update(this.ClientSize.Width, this.ClientSize.Height);
            else
             SplashScreen.Update(this.ClientSize.Width, this.ClientSize.Height);

            // без этого мы не получим Timer_Tick
            if (buttonStart != null)
                Application.DoEvents();
            this.Invalidate();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            _startGame = true;
            buttonStart.Hide();
            // фокусируемся на форме для перехвата сообщений
            this.Focus();
        }

        private void CanvasForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (Game.GameEnd) return;
            Game.KeyDown(sender, e);
        }

    }

}
