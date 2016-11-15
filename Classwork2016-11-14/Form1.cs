using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication6
{
    public partial class Form1 : Form
    {
        Student st;
        BindingSource bs;

        public Form1()
        {
            InitializeComponent();

            st = new Student(102, "Ivanov", 80);

            //st.stIDChange += St_stIDChange;
            //st.stNameChange += St_stNameChange;
            //st.stRateChange += St_stRateChange;

            //textBoxID.TextChanged += TextBoxID_TextChanged;
            //textBoxName.TextChanged += TextBoxName_TextChanged;
            //textBoxRate.TextChanged += TextBoxRate_TextChanged;

            bs = new BindingSource();
            bs.DataSource = st;
            textBoxID.DataBindings.Add("Text", bs, "StID");

            //Binding b = new Binding("Text", st, "StID");
            //b.ControlUpdateMode = ControlUpdateMode.OnPropertyChanged;
            //b.DataSourceUpdateMode = DataSourceUpdateMode.OnValidation;
            //textBoxID.Validating += TextBoxID_Validating;
            //textBoxID.DataBindings.Add(b);

            textBoxName.DataBindings.Add("Text", bs, "StName");
            textBoxRate.DataBindings.Add("Text", bs, "StRate");
        }

        private void TextBoxID_Validating(object sender, CancelEventArgs e)
        {
            int i;
            if (!int.TryParse(textBoxID.Text, out i))
            {
                MessageBox.Show("Введіть число");
                e.Cancel = true;
            }
        }

        private void St_stIDChange(object sender, EventArgs e)
        {
            textBoxID.Text = st.StID.ToString();
        }

        private void St_stNameChange(object sender, EventArgs e)
        {
            textBoxName.Text = st.StName;
        }

        private void St_stRateChange(object sender, EventArgs e)
        {
            textBoxRate.Text = st.StRate.ToString();
        }

        private void TextBoxID_TextChanged(object sender, EventArgs e)
        {
            st.StID = int.Parse(textBoxID.Text);
        }

        private void TextBoxName_TextChanged(object sender, EventArgs e)
        {
            st.StName = textBoxName.Text;
        }

        private void TextBoxRate_TextChanged(object sender, EventArgs e)
        {
            st.StRate = float.Parse(textBoxRate.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(st.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            st.StID += 1;
            bs.ResetBindings(false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            st.StName = st.StName + "a";
            bs.ResetBindings(false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            st.StRate += 1;
            bs.ResetBindings(false);
        }
    }

    public class Student
    {
        int stID;
        string stName;
        float stRate;

        public Student()
        {
            stID = 0;
            stName = string.Empty;
            stRate = 0.0f;
        }

        public Student(int _stID, string _stName, float _stRate)
        {
            stID = _stID;
            stName = _stName;
            stRate = _stRate;
        }

        public override string ToString()
        {
            return "ID=" + StID + " NAME=" + StName + " RATE=" + StRate;
        }

        public event EventHandler stIDChange;
        public event EventHandler stNameChange;
        public event EventHandler stRateChange;

        public int StID
        {
            get { return stID; }
            set
            {
                stID = value;
                if (stIDChange != null)
                {
                    stIDChange(this, EventArgs.Empty);
                }
            }
        }

        public string StName
        {
            get { return stName; }
            set
            {
                stName = value;
                if (stNameChange != null)
                {
                    stNameChange(this, EventArgs.Empty);
                }
            }
        }

        public float StRate
        {
            get { return stRate; }
            set
            {
                stRate = value;
                if (stRateChange != null)
                {
                    stRateChange(this, EventArgs.Empty);
                }
            }
        }
    }
}