using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Classwork2016_11_16
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //GDI+ .NET Framework
            ResizeRedraw = true;
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (LinearGradientBrush sdf = new LinearGradientBrush(ClientRectangle, Color.Black, Color.Gray, LinearGradientMode.ForwardDiagonal))
            {
               e.Graphics.FillRectangle(sdf, ClientRectangle);
            }
            e.Graphics.DrawRectangle(new Pen(Color.Black, 4), ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height);
        }
    }
}