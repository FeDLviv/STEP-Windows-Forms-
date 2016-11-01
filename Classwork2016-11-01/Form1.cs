using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Classwork2016_11_01
{
    public partial class Form1 : Form
    {
        List<Order> list = new List<Order>();
        TabControl tab = new TabControl();
        NumericUpDown upD = new NumericUpDown();
        TrackBar barR = new TrackBar();
        TrackBar barG = new TrackBar();
        TrackBar barB = new TrackBar();

        public Form1()
        {
            InitializeComponent();

            //TABCONTROL
            tab.Controls.Add(new TabPage("FlowLayout"));
            tab.Controls.Add(new TabPage("CREATE ORDER"));
            //tab.ShowToolTips = true;
            tab.Dock = DockStyle.Fill;
            tab.Parent = this;

            GetOrderPanel().Parent = tab.Controls[1];
            
            //FLOWLAYOUTPANEL
            FlowLayoutPanel panel = new FlowLayoutPanel();
            panel.Dock = DockStyle.Fill;
            panel.Parent = tab.Controls[0];

            //CONTEXTMENU
            //ContextMenu menu = new ContextMenu();

            //NOTIFYICON
            NotifyIcon icon = new NotifyIcon();
            icon.Text = "Моя програма";
            icon.Icon = SystemIcons.Exclamation;
            icon.Visible = true;
            //icon.ContextMenu = menu;
            icon.ShowBalloonTip(1000, "ГИ-ги-ги", "УРЯ", ToolTipIcon.Info);

            //TRACKBAR
            barR = new TrackBar();
            barR.Parent = panel;
            barR.Minimum = 1;
            barR.Maximum = 250;
            barR.Value = 1;
            barR.TickFrequency = 50;
            barR.Orientation = Orientation.Vertical;
            barR.Size = new Size(200, 100);
            barR.Scroll += SetColor;

            barG = new TrackBar();
            barG.Parent = panel;
            barG.Minimum = 1;
            barG.Maximum = 250;
            barG.Value = 1;
            barG.TickFrequency = 50;
            barG.Orientation = Orientation.Vertical;
            barG.Size = new Size(200, 100);
            barG.Scroll += SetColor;

            barB = new TrackBar();
            barB.Parent = panel;
            barB.Minimum = 1;
            barB.Maximum = 250;
            barB.Value = 1;
            barB.TickFrequency = 50;
            barB.Orientation = Orientation.Vertical;
            barB.Size = new Size(200, 100);
            barB.Scroll += SetColor;

            //TOOLTIP
            ToolTip tip = new ToolTip();
            tip.IsBalloon = true;
            tip.InitialDelay = 1000;
            tip.AutoPopDelay = 5000;
            tip.SetToolTip(barR, "RED");
            tip.SetToolTip(barG, "GREEN");
            tip.SetToolTip(barB, "BLUE");

            //VSCROLLBAR
            //HSCROLLBAR
            VScrollBar vScr = new VScrollBar();
            vScr.Parent = panel;
            HScrollBar hScr = new HScrollBar();
            hScr.Parent = panel;            
        }

        private FlowLayoutPanel GetOrderPanel()
        {
            FlowLayoutPanel panel = new FlowLayoutPanel();
            panel.AutoScroll = true;
            panel.WrapContents = false;
            panel.FlowDirection = FlowDirection.TopDown;
            panel.Dock = DockStyle.Fill;

            Label label = new Label();
            //label.DataBindings.Add("Text", list, "Count");
            label.Parent = panel;

            PropertyGrid prG = new PropertyGrid();
            prG.SelectedObject = new Order();
            prG.Parent = panel;
            prG.Size = new Size(200, 200);

            Button but = new Button();
            but.Text = "НОВЕ";
            but.Parent = panel;
            but.Click += (obj, ea) =>
            {
                list.Add(prG.SelectedObject as Order);
                label.Text = list.Count.ToString();
                prG.SelectedObject = new Order();
                upD.Maximum = list.Count - 1;
                if (list.Count == 1)
                {
                    tab.Controls.Add(new TabPage("LIST ORDER"));
                    GetListOrderPanel().Parent = tab.Controls[2];
                }
            };
            return panel;
        }

        private FlowLayoutPanel GetListOrderPanel()
        {
            FlowLayoutPanel panel = new FlowLayoutPanel();
            panel.AutoScroll = true;
            panel.WrapContents = false;
            panel.FlowDirection = FlowDirection.TopDown;
            panel.Dock = DockStyle.Fill;

            Label label = new Label();
            label.Text = list.Count.ToString();
            label.Parent = panel;

            PropertyGrid prG = new PropertyGrid();
            prG.SelectedObject = new Order();
            prG.Parent = panel;
            prG.Size = new Size(200, 200);

            upD.Minimum = 0;
            upD.Maximum = list.Count - 1;
            upD.Increment = 1;
            upD.DecimalPlaces = 0;
            upD.ReadOnly = true;
            upD.AutoSize = true;
            upD.Parent = panel;
            upD.ValueChanged += (obj, ea) =>
            {
                if (upD.Value >= 0 && upD.Value < list.Count)
                {
                    prG.SelectedObject = list[(int)upD.Value];
                }
            };

            return panel;
        }

        private void SetColor(object sender, EventArgs e)
        {
            BackColor = Color.FromArgb(barR.Value, barG.Value, barB.Value);
        }
    }

    public class Order
    {
        public string Name { get; set; }
        public string Material { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public decimal Sum { get; set; }
    }
}