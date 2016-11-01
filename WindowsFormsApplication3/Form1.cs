using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        List<Student> list = new List<Student>()
            {
                new Student(1, "Кузьмінський", 1990, "s25-vp1"),
                new Student(2, "Власов", 1989, null),
                new Student(3, "Пристайко", 2000, "s25-vp1"),
                new Student(4, "Пишний", 1985, "s25-vp1")
            };

        public Form1()
        {
            InitializeComponent();

            //FORM
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;

            //FLOWLAYOUTPANEL
            FlowLayoutPanel panel = new FlowLayoutPanel();
            panel.BackColor = Color.Beige;
            panel.AutoSize = true;
            panel.Dock = DockStyle.Fill;
            panel.Parent = this;

            //PROPERTYGRID
            PropertyGrid pg = new PropertyGrid();
            pg.SelectedObject = list[0];
            pg.Margin = new Padding(50, 10, 50, 20);
            pg.MinimumSize = new Size(300, 300);
            pg.Parent = panel;

            //PROGRESSBAR
            ProgressBar pr = new ProgressBar();
            pr.Minimum = 0;
            pr.Maximum = list.Count -1;
            pr.Step = 1;
            pr.AutoSize = true;
            pr.Parent = panel;

            //NUMERICUPDOWN
            NumericUpDown upD = new NumericUpDown();
            upD.Minimum = 0;
            upD.Maximum = list.Count - 1;
            upD.Increment = 1;
            upD.DecimalPlaces = 0;
            upD.ReadOnly = true;
            upD.AutoSize = true;
            upD.Parent = panel;
            upD.ValueChanged += (obj, ea) =>
            {
                pg.SelectedObject = list[(int) upD.Value];
            };

            //DOMAINUPDOWN
            DomainUpDown upDom = new DomainUpDown();
            object[] ar = typeof(Color).GetProperties(BindingFlags.Public | BindingFlags.Static);
            upDom.Items.Add(ar[5]);
            upDom.ReadOnly = true;
            upDom.AutoSize = true;
            upDom.Parent = panel;
            upDom.SelectedItemChanged += (obj, ea) =>
            {
                string temp = upDom.SelectedItem.ToString();
                string color = temp.Remove(0, 21);
                //BackColor = (Color) ((typeof(Color)).GetProperty(color)).GetValue(null, null);
            };
            

            //BUTTON
            Button but = new Button() { Text = "НАСТУПНИЙ", BackColor = Color.Gray, AutoSize = true, Parent = panel };
            but.MouseDown += (obj, ea) =>
            {
                if (ea.Button == MouseButtons.Left) 
                {
                     pr.PerformStep();
                }
                else 
                {
                    if (pr.Value >= pr.Step)
                    {
                        pr.Value -= pr.Step;
                    }
                }
            };
        }


    }

    class Student
    {
        //не відображати властивість
        [Browsable(false)] 
        public int ID { set; get; }
        //ім'я властивості при відображенні, опис властивості, тільки читання властивості
        [DisplayName("Ім'я"), Description("Прізвище студента"), ReadOnly(true)]
        //[TypeConverter(typeof(JobTitleTypeConverter))]
        public string Name { set; get; }
        //ім'я властивості при відображенні, опис властивості, категорія до якої належить властивість
        [DisplayName("Рік"), Description("Рік народження студента"), Category("Решта даних")]
        public int Year { get; set; }
        //ім'я властивості при відображенні, опис властивості, категорія до якої належить властивість
        [DisplayName("Група"), Description("Група в якій навчається студент"), Category("Решта даних")]
        public string Group { get; set; }

        public Student(int id, string name, int year, string group)
        {
            ID = id;
            Name = name;
            Year = year;
            Group = group;
        }
    }
}