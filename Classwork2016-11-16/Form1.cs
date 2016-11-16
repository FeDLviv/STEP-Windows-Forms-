using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Classwork2016_11_16
{
    public partial class Form1 : Form
    {
        Rectangle rectPupil = new Rectangle(0, 0, 10, 10);
        Rectangle rectEays = new Rectangle(0, 0, 80, 80);

        public Form1()
        {
            InitializeComponent();
            
            //GDI+ .NET Framework
            ResizeRedraw = true; //для перемальовування при зміні розміру форми
            DoubleBuffered = true;

            rectPupil.X = ClientRectangle.Width / 2 - rectPupil.Height / 2;
            rectPupil.Y = ClientRectangle.Height / 2 - rectPupil.Height / 2;
            rectEays.X = ClientRectangle.Width / 2 - 40;
            rectEays.Y = ClientRectangle.Height / 2 - 40;

            MouseMove += Form1_MouseMove;
        }

        

        protected override void OnPaint(PaintEventArgs e)
        {
            using (LinearGradientBrush sdf = new LinearGradientBrush(ClientRectangle, Color.Black, Color.Gray, LinearGradientMode.ForwardDiagonal))
            {
               e.Graphics.FillRectangle(sdf, ClientRectangle); // замальовування площі
            }
            e.Graphics.DrawRectangle(new Pen(Color.Black, 4), ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height); // малювання площі

            e.Graphics.DrawEllipse(new Pen (Color.Red, 2), ClientRectangle.Width / 2 - 40, ClientRectangle.Height / 2 - 40, 80, 80); // малювання кола
            e.Graphics.FillEllipse(new SolidBrush(Color.Blue), rectPupil);    
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            int x = ((rectEays.Width * e.X) / ClientRectangle.Width) + ClientRectangle.Width / 2 - rectEays.Width / 2 - rectPupil.Width/2;
            int y = ((rectEays.Height * e.Y) / ClientRectangle.Height) + ClientRectangle.Height / 2 - rectEays.Height / 2 - rectPupil.Height / 2;
            //int xxx = 
            //int y = ((rectEays.Height * e.Y) / xxx) + ClientRectangle.Height / 2 - rectEays.Height / 2 - rectPupil.Height / 2; 

            rectPupil.X = x;
            rectPupil.Y = y;

            Invalidate();
        }
    }
}