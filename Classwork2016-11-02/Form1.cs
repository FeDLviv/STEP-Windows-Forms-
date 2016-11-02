using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Classwork2016_11_02
{
    public partial class Form1 : Form
    {
        List<string> list = new List<string>() { "Abc", "Aog", "BCD" };
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SecondForm s = new SecondForm();
            if (s.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show("Cancel");
            }
        }
    }
}
