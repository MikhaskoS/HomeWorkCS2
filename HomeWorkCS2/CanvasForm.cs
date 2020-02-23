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
            _startGame = false;


            Timer timer = new Timer { Interval = 60 };
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Canvas_FormClosing(object sender, FormClosingEventArgs e)
        {
            _closing = true;
        }

        private bool _closing = false;
        private bool _startGame = false;
        private static Graphics _grfx;
        public static Graphics Grfx { get => _grfx;}

        private  void Timer_Tick(object sender, EventArgs e)
        {
            if (_startGame)
                Game.FrameUpdate();
            else
                SplashScreen.FrameUpdate();
        }

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

            this.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _startGame = true;
            button1.Hide();
        }
    }

}
