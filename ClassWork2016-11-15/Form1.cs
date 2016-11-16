using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ClassWork2016_11_15
{
    public partial class Form1 : Form
    {
        List<Student> list = new List<Student>() { new Student("ПАВЛО", 20, "чоловіча"), new Student("СЕРГІЙ", 25, "чоловіча"), new Student("ФЕДЬКО", 14, "чоловіча") };
        BindingSource source = new BindingSource();
        
        public Form1()
        {
            InitializeComponent();

            source.DataMember = "Student";
            source.DataSource = list;

            bindingNavigator.BindingSource = source;

            textBox1.DataBindings.Add("Text", source, "Name");
            textBox2.DataBindings.Add("Text", source, "Age");
            textBox3.DataBindings.Add("Text", source, "Sex");

            //DATAGRIDVIEW
            DataGridView table = new DataGridView();
            table.Dock = DockStyle.Bottom;
            table.Parent = this;
            //table.ColumnCount = 3;
            table.Columns.Add("name", "ім'я");
            table.Columns.Add("age", "вік");
            DataGridViewComboBoxColumn columnSex = new DataGridViewComboBoxColumn();
            columnSex.HeaderText = "стать";
            columnSex.Name = "sex";
            columnSex.DataSource = new string[] { "невизначено", "чоловіча", "жіноча" };
            columnSex.ValueType =  typeof(string);
            columnSex.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            table.Columns.Add(columnSex);

            //table.DataSource = list;
            foreach (Student x in list)
            {
                int i = table.Rows.Add();
                table["name", i].Value = x.Name;
                table["age", i].Value = x.Age;
                table["sex", i].Value = x.Sex;
            }

            foreach (DataGridViewRow x in table.Rows)
            {
                Student st = new Student();
                st.Name = (string) x.Cells["name"].Value;
                //st.Age =  (int) x.Cells["age"].Value; !!!
                st.Name = (string) x.Cells["sex"].Value;
            }
        }
    }

    public class Student
    {
        string name;
        int age;
        string sex;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }

        public Student()
        {

        }

        public Student(string name, int age, string sex)
        {
            Name = name;
            Age = age;
            Sex = sex;
        }
    }
}