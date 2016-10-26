using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            AutoSize = true;

            //LABEL
            Label lab = new Label();
            lab.Text = "Danil";
            lab.Parent = this; //Controls.Add(lab);
            lab.Location = new System.Drawing.Point(5, 5);

            //TEXTBOX
            TextBox tBox = new TextBox();
            tBox.Parent = this; //Controls.Add(tBox);
            tBox.Location = new System.Drawing.Point(5, 30);
            
            //PICTUREBOX
            PictureBox pBox = new PictureBox();
            pBox.Size = new System.Drawing.Size(150, 150);
            pBox.SizeMode = PictureBoxSizeMode.Zoom;
            pBox.Image = Image.FromFile("messi.jpg"); //pbox.ImageLocation = "messi.jpg";
            pBox.Parent = this; //Controls.Add(pBox);
            pBox.Location = new System.Drawing.Point(100, 5);

            //IMAGELIST
            ImageList iList = new ImageList();
            Image image = Image.FromFile("messi.jpg");
            iList.Images.Add("picture1", image);

            //CHECKBOX
            CheckBox cBox = new CheckBox();
            cBox.Text = "GoldenByte";
            cBox.Parent = this; //Controls.Add(cBox);
            cBox.Location = new System.Drawing.Point(5, 60);

            //RADIOBUTTON
            RadioButton rBut = new RadioButton();
            rBut.Text = "GoldenByte";
            rBut.Parent = this; //Controls.Add(rBut);
            rBut.Location = new System.Drawing.Point(5, 90);

            //BUTTON
            Button but = new Button();
            but.Text = "Start";
            but.Parent = this; //Controls.Add(but);
            but.Location = new System.Drawing.Point(5, 120);
            but.DialogResult = DialogResult.OK; //якщо форма запускається, як модальне діалогове вікно ShowDialog()
            but.Click += (obj, ea) => { MessageBox.Show(cBox.Checked.ToString()); };

            //GROUPBOX
            GroupBox gBox = new GroupBox();
            gBox.Text = "GroupBox";
            gBox.Parent = this; //Controls.Add(gBox);
            gBox.Location = new System.Drawing.Point(5, 160);

            //DateTime AND TimeSpan
            DateTime dTime = new DateTime(2016, 10, 26);
            TimeSpan tSpan = new TimeSpan(1, 0, 0, 0);
            lab.Text = dTime.ToString();

            //DATETIMEPICKER
            DateTimePicker pick = new DateTimePicker();
            pick.Value = dTime + tSpan;
            pick.Parent = this; //Controls.Add(pick);
            pick.Location = new System.Drawing.Point(210, 200);

            //MONTHCALENDAR
            MonthCalendar cal = new MonthCalendar();
            cal.Parent = this; //Controls.Add(cal);
            cal.Location = new System.Drawing.Point(250, 5);
            cal.DateChanged += (obj, ea) => { lab.Text = cal.SelectionRange.Start.ToString(); };

            //PROGRESSBAR
            ProgressBar pBar = new ProgressBar();
            pBar.Style = ProgressBarStyle.Marquee;
            pBar.Parent = this; //Controls.Add(pBar);
            pBar.Location = new System.Drawing.Point(5, 270);
        }
    }
}