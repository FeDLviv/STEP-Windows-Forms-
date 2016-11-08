using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication5
{
    public partial class Form1 : Form
    {
        FlowLayoutPanel panel = new FlowLayoutPanel();
        public Form1()
        {
            InitializeComponent();

            panel.Parent = this;
            panel.AutoSize = true;
            panel.Dock = DockStyle.Fill;
            

            //MENUSTRIP
            MenuStrip menu = new MenuStrip();
            menu.Parent = this;

            //TOOLSTRIPCONTROLHOST
            MyLabel label = new MyLabel("Ги-ги ");
            menu.Items.Add(new ToolStripControlHost(label));

            //IMAGELIST
            ImageList list = new ImageList();
            list.Images.Add("open", Image.FromFile("picture.bmp"));
            menu.ImageList = list;

            //TOOLSTRIPMENUITEM
            ToolStripMenuItem item = new ToolStripMenuItem("Image");
            item.ImageKey = "open";
            menu.Items.Add(item);

            //CONTEXTMENUSTRIP
            ContextMenuStrip conMenu = new ContextMenuStrip();
            conMenu.Items.Add(new ToolStripMenuItem("Hello"));
            label.ContextMenuStrip = conMenu;

            
            //TOOLSTRIP
            ToolStrip tool = new ToolStrip();
            tool.Items.Add(new ToolStripButton("Save"));
            tool.Items.Add(new ToolStripComboBox());
            tool.Items.Add(new ToolStripSplitButton());
            
            //TOOLSTRIPPANEL
            ToolStripPanel strPanel = new ToolStripPanel();
            strPanel.Dock = DockStyle.Left;
            strPanel.Parent = panel;
            strPanel.Join(tool);

            //TOOLSTRIPCONTAINER
            //ToolStripContainer container = new ToolStripContainer();
            //container.LeftToolStripPanel.Controls.Add(tool);
            //container.Parent = panel;

            //STATUSSTRIP
            StatusStrip status = new StatusStrip();
            ToolStripStatusLabel lab = new ToolStripStatusLabel("Стоп");
            status.Items.Add(lab);
            status.Items.Add(new ToolStripButton("Оновити"));
            status.Parent = this;

        }
    }

    public class MyLabel : Label
    {
        public MyLabel(string text)
        {
            Text = text;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (Enabled)
            {
                base.OnPaint(e);
            }
            else
            {
                using (Brush brush = new SolidBrush(Color.Red))
                {
                    e.Graphics.DrawString(Text, Font, brush, ClientRectangle);
                }
            }
        }
    }
}