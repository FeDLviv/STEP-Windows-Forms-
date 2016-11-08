using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ClassWork2016_11_08
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FlowLayoutPanel panel = new FlowLayoutPanel();
            panel.Dock = DockStyle.Fill;
            panel.Parent = this;
            Button buttonO = new Button();
            buttonO.Text = "OPEN";
            buttonO.Parent = panel;
            Button buttonS = new Button();
            buttonS.Text = "SAVE";
            buttonS.Parent = panel;
            RichTextBox text = new RichTextBox();
            text.Size = new Size(200, 200);
            text.Multiline = true;
            //text.ScrollBars = ScrollBars.Both;
            text.Parent = panel;

            //OPENFILEDIALOG
            OpenFileDialog ofDialog = new OpenFileDialog();

            //SAVEFILEDIALOG
            SaveFileDialog sfDialog = new SaveFileDialog();

            //COLORDIALOG
            ColorDialog colDialog = new ColorDialog();

            //FONTDIALOG
            FontDialog fontDialog = new FontDialog();

            //PRINTDIALOG
            PrintDialog prDialog = new PrintDialog();

            //PRINTPREVIEWDIALOG
            PrintPreviewDialog prPrDialog = new PrintPreviewDialog();

            //FOLDERBROWSERDIALOG
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();

            buttonO.Click += (obj, ea) =>
            {
                ofDialog.ShowReadOnly = true; //чекбокс - (тільки для читання)
                ofDialog.Filter = "всі файли|*.*|текстові|*.txt"; //філтьтр для вибору файлів
                if (ofDialog.ShowDialog() == DialogResult.OK)
                {
                    StreamReader file = new StreamReader(ofDialog.OpenFile()); // повертає потік    
                    text.Text = file.ReadToEnd();
                    file.Dispose();
                    if (ofDialog.ReadOnlyChecked)
                    {
                        text.ReadOnly = true;
                    }
                }
            };

            buttonS.Click += (obj, ea) =>
            {
                sfDialog.AddExtension = true;
                if (sfDialog.ShowDialog() == DialogResult.OK && !text.ReadOnly)
                {
                    StreamWriter file = new StreamWriter(sfDialog.OpenFile());
                    file.Write(text.Text);
                    file.Dispose();
                }
            };
        }
    }
}
