using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button temp = sender as Button;
            if (temp.Text == "Start")
            {
                temp.Text = "Stop";
                timer1.Start();
            }
            else
            {
                temp.Text = "Start";
                timer1.Stop();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
