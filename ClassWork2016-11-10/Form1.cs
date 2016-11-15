using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication5
{
    public partial class Form1 : Form
    {
        DataObject data = new DataObject();

        public Form1()
        {
            InitializeComponent();
            //LISTVIEW
            /*
            ListView list = new ListView();
            list.View = View.Details;

            list.Columns.Add("1");
            list.Columns.Add("2");

            list.Items.Add(new ListViewItem("Java"));
            list.Items[0].SubItems.Add("COOL");

            list.Dock = DockStyle.Fill;
            list.Parent = this;

            //list.Items.Remove(list.SelectedItems[0]);
            */

            //DRAGandDROP
            textBox1.AllowDrop = true;
            listBox1.MouseDown += ListBox1_MouseDown;
            textBox1.DragEnter += TextBox1_DragEnter;
            textBox1.DragDrop += TextBox1_DragDrop;

            listBox1.AllowDrop = true;
            listBox1.DragEnter += ListBox1_DragEnter;
            listBox1.DragDrop += ListBox1_DragDrop;
        }

        //метод "обирає" дані в списку при натисканні на список
        private void ListBox1_MouseDown(object sender, MouseEventArgs e)
        {
            data.SetData(DataFormats.StringFormat, listBox1.SelectedItem);
            listBox1.DoDragDrop(data, DragDropEffects.Copy); //ефекти мають бути однакові
        }

        //метод коли дані "заходять" в компонент TEXTBOX
        private void TextBox1_DragEnter(object sender, DragEventArgs e)
        {
            //перевірка чи підходять дані для переміщення
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                e.Effect = DragDropEffects.Copy; //ефекти мають бути однакові
            }
            else
            {
                e.Effect = DragDropEffects.None;
            } 
        }

        // метод коли клавіша миші відпускається при переміщенні
        private void TextBox1_DragDrop(object sender, DragEventArgs e)
        {
            StreamReader sr = new StreamReader(e.Data.GetData(DataFormats.StringFormat).ToString());
            TextBox temp = textBox1 as TextBox;
            temp.Text = sr.ReadToEnd();
        }

        private void ListBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void ListBox1_DragDrop(object sender, DragEventArgs e)
        {
            ListBox temp = sender as ListBox;
            string[] arr = (string[]) e.Data.GetData(DataFormats.FileDrop);
            foreach (string x in arr)
            {
                temp.Items.Add(x);
            }
        }

        //[System.Runtime.InteropServices.DllImport("user32.dll")]
        //private static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);
        //public const int HWND_BOTTOM = 0x1;
        //public const int SWP_NOSIZE = 0x1;
        //public const int SWP_NOMOVE = 0x2;
        //public const int SWP_SHOWWINDOW = 0x40;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0046) //WM_WINDOWPOSCHANGING
            {
                //SetWindowPos(Handle, HWND_BOTTOM, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW);
                //m.Msg |= 0x0004; // SWP_NOZORDER
                SendToBack();     
            }
            base.WndProc(ref m);
        }
    }
}
