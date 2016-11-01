using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        Point start;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        public Form1()
        {
            InitializeComponent();

            //PANEL GROUPBOX FLOWLAYOUTPANEL
            //FLOWLAYOUTPANEL
            FlowLayoutPanel panel = new FlowLayoutPanel();
            panel.AutoScroll = true;
            panel.BackColor = Color.Plum;
            panel.Size = Size;
            panel.Parent = this;
            panel.MouseDown += (obj, ea) => { start = ea.Location; };
            panel.MouseMove += (obj, ea) => 
            {
                if (ea.Button == MouseButtons.Left)
                {
                    Point cur = ea.Location;
                    this.Left += cur.X - start.X;
                    this.Top += cur.Y - start.Y;
                }
            };

            //LISTBOX
            ListBox list = new ListBox();
            list.SelectionMode = SelectionMode.One;
            list.MultiColumn = false;
            list.Items.Add("Кузя");
            list.Items.Add(new Point2D(3, 3));
            list.Items.AddRange(new string[] { "Федько", "Олексій" });
            list.Parent = panel;

            //CHECKEDLISTBOX
            CheckedListBox chBox = new CheckedListBox();
            chBox.Items.AddRange(new string[] { "Лось", "Ведмідь", "Білка", "Пес" });
            chBox.Parent = panel;
            chBox.KeyDown += (obj, ea) =>
            {
                if (ea.Control && ea.KeyCode == Keys.C)
                {
                    CheckedListBox temp = obj as CheckedListBox;
                    if (temp.CheckedItems.Count > 0)
                    {
                        foreach (object x in temp.CheckedItems)
                        {
                            list.Items.Add(x);
                        }
                    }
                }
            };

            //!!!OnParent
            //COMBOBOX
            ComboBox cBox = new ComboBox();
            cBox.Items.AddRange(new string[] { "кава", "чай", "сік" });
            cBox.Parent = panel;
            
            //LABEL
            Label label = new Label();
            label.Text = "СУПЕР лейба";
            label.BorderStyle = BorderStyle.FixedSingle;
            label.Parent = panel;

            //BUTTON
            Button button = new Button();
            button.Text = "Click";
            button.Parent = panel;
            button.Click += (obj, ea) => 
            {
                if (list.SelectedIndex > 0)
                {
                    MessageBox.Show(list.SelectedItem.ToString());
                }
            };

            //!!!OnParent
            //TOOLTIP
            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(button, "ФЕДЬКО");
            toolTip1.SetToolTip(label, "КУЗЯ");

            //HANDLER
            MouseEventHandler handler = new MouseEventHandler(OnParent);
            for (int i = 0; i < panel.Controls.Count; i++)
            {
                //panel.Controls[i].MouseMove += handler;
            }

            this.SizeChanged += (obj, ea) => { panel.Size = Size; };
        }

        private void OnParent(object obj, MouseEventArgs mea)
        {
            (obj as Control).Capture = false;
            Message msg = Message.Create(Handle, WM_NCLBUTTONDOWN, (IntPtr) HT_CAPTION, IntPtr.Zero);
            WndProc(ref msg);
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }

    public class Point2D
    {
        int x;
        int y;

        public Point2D(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}