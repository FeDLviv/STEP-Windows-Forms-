using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClassWork2016_11_09
{
    public partial class Form1 : Form
    {
        TreeView tree;
        ContextMenuStrip menu = new ContextMenuStrip();

        public Form1()
        {
            InitializeComponent();

            //IMAGELIST
            ImageList images = new ImageList();
            images.ImageSize = new Size(24, 24);
            images.Images.Add(Image.FromFile("Smile.bmp"));
            images.Images.Add(Image.FromFile("Free bsd.bmp"));
            images.Images.Add(Image.FromFile("Apply.bmp"));

            //TREEVIEW (TREENODE)
            tree = new TreeView();
            tree.ImageList = images;
            tree.NodeMouseClick += Tree_NodeMouseClick;
            //tree.CheckBoxes = true; //додавання чекбоксів до вузлів дерева

            TreeNode java = new TreeNode("Java", 0, 2);
            java.Nodes.Add(new TreeNode("JDK 1.0 (1996)", 1, 2));
            java.Nodes.Add(new TreeNode("JDK 1.1 (1997)", 1, 2));
            java.Nodes.Add(new TreeNode("J2SE 1.2 (1998)", 1, 2));
            java.Nodes.Add(new TreeNode("J2SE 1.3 (2000)", 1, 2));
            java.Nodes.Add(new TreeNode("J2SE 1.4 (2002)", 1, 2));
            java.Nodes.Add(new TreeNode("J2SE 5.0 (2005)", 1, 2));
            java.Nodes.Add(new TreeNode("Java SE 6 (2006)", 1, 2));
            java.Nodes.Add(new TreeNode("Java SE 7 (2011)", 1, 2));
            java.Nodes.Add(new TreeNode("Java SE 8 (2014)", 1, 2));
            TreeNode cSharp = new TreeNode("C#", 0, 2);
            cSharp.Nodes.Add(new TreeNode("C# 1.0 (2002)", 1, 2));
            cSharp.Nodes.Add(new TreeNode("C# 1.2 (2003)", 1, 2));
            cSharp.Nodes.Add(new TreeNode("C# 2.0 (2006)", 1, 2));
            cSharp.Nodes.Add(new TreeNode("C# 3.0 (2007)", 1, 2));
            cSharp.Nodes.Add(new TreeNode("C# 4.0 (2010)", 1, 2));
            cSharp.Nodes.Add(new TreeNode("C# 5.0 (2013)", 1, 2));
            cSharp.Nodes.Add(new TreeNode("C# 6.0 (2015)", 1, 2));

            tree.Nodes.Add(java);
            tree.Nodes.Add(cSharp);

            AddContextMenuToRoot(java);
            AddContextMenuToRoot(cSharp);

            ToolStripMenuItem delete = new ToolStripMenuItem("DELETE");
            delete.Click += Delete_Click;
            ToolStripMenuItem edit = new ToolStripMenuItem("EDIT");
            edit.Click += Edit_Click;
            menu.Items.Add(delete);
            menu.Items.Add(edit);

            foreach (TreeNode x in java.Nodes)
            {
                x.ContextMenuStrip = menu;
            }

            foreach (TreeNode x in cSharp.Nodes)
            {
                x.ContextMenuStrip = menu;
            }

            tree.Dock = DockStyle.Fill;
            tree.Parent = this;
        }

        //метод обирає вузол дерева при натисканні мишкою на ньому (права клавіша миші враховується)
        private void Tree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            tree.SelectedNode = e.Node;
        }

        //метод додає контекстне меню до корня дерева
        private void AddContextMenuToRoot(TreeNode root)
        {
            ContextMenuStrip menu = new ContextMenuStrip();
            ToolStripMenuItem add = new ToolStripMenuItem("ADD");
            menu.Items.Add(add);
            add.Click += Add_Click;
            root.ContextMenuStrip = menu;
        }

        //метод обробник пункта контекстного меню CREATE
        private void Add_Click(object sender, EventArgs e)
        {
            TreeNode newNode = tree.SelectedNode.Nodes.Add("NEW");
            tree.SelectedNode = newNode;
            newNode.ContextMenuStrip = menu;
        }

        //метод обробник пункта контекстного меню DELETE
        private void Delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete node?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                tree.Nodes.Remove(tree.SelectedNode);
            }
        }

        //метод обробник пункта контекстного меню EDIT
        private void Edit_Click(object sender, EventArgs e)
        {
            tree.LabelEdit = true;
            tree.SelectedNode.BeginEdit();
        }

        //прохід по вузлах дерева
        private void AllTreeNodes(TreeNodeCollection tree)
        {
            foreach(TreeNode x in tree)
            {
                Console.WriteLine(x.Text);
                if (x.GetNodeCount(false) >0 )
                {
                    AllTreeNodes(x.Nodes);
                }
            }
        }
    }
}