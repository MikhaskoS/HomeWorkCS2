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
    public partial class Canvas : Form
    {
        public Canvas()
        {
            // Здесь устанавливается двойной буффер!
            this.SetStyle(ControlStyles.DoubleBuffer |
                 ControlStyles.UserPaint |
                 ControlStyles.AllPaintingInWmPaint,
                 true);

            InitializeComponent();

            Game.Init(this.ClientSize.Width, this.ClientSize.Height);
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            // начало координат в центре экрана
            Graphics grfx = e.Graphics;
            grfx.TranslateTransform(this.ClientSize.Width / 2, this.ClientSize.Height / 2);
            grfx.ScaleTransform(1, 1);

            Game.Update(grfx, this.ClientSize.Width, this.ClientSize.Height);

            this.Invalidate();
        }
    }

}
