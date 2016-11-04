using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    //MENU
    public partial class Form1 : Form
    {
        Color color;
        public Form1()
        {
            InitializeComponent();
            color = BackColor;
                        
            //MENUSTRIP
            MenuStrip mainMenu = new MenuStrip();

            //TOOLSTRIPMENUITEM, TOOLSTRIPSEPARATOR, TOOLSTRIPTEXTBOX, TOOLSTRIPCOMBOBOX
            ToolStripMenuItem menuF = new ToolStripMenuItem("File");
            ToolStripMenuItem menuS = new ToolStripMenuItem("Save");
            ToolStripSeparator menuSep = new ToolStripSeparator();
            ToolStripMenuItem menuC = new ToolStripMenuItem("Yellow color");
            ToolStripTextBox menuT = new ToolStripTextBox();
            ToolStripComboBox menuCB = new ToolStripComboBox();
            ToolStripMenuItem menuE = new ToolStripMenuItem("Exit");

            menuF.DropDownItems.Add(menuS);
            menuF.DropDownItems.Add(menuSep);
            menuF.DropDownItems.Add(menuC);
            menuF.DropDownItems.Add(menuT);
            menuF.DropDownItems.Add(menuCB);

            menuS.ShortcutKeys = Keys.Alt | Keys.S;
            menuS.ShowShortcutKeys = true;
            menuS.Click += (obj, ea) => { MessageBox.Show("Save file... ;)"); };

            menuC.CheckOnClick = true;
            menuC.CheckedChanged += (obj, ea) =>
            {
                if (menuC.Checked)
                {
                    BackColor = Color.Yellow;
                }
                else
                {
                    BackColor = color;
                }
            };

            menuE.Click += (obj, ea) => { Close(); };
            
            mainMenu.Items.Add(menuF);
            mainMenu.Items.Add(menuE);

            mainMenu.Parent = this;
        }
    }
}