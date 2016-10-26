using System;
using System.Collections.Generic;
using System.Linq;

using System.Windows.Forms; //простір імен для Windows Forms

namespace WindowsFormsApplication
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //власноруч створюємо форму
            /*
            Form form = new Form(); //створити форму
            form.BackColor = System.Drawing.Color.Yellow; //задати колір фона на формі

            Button but = new Button(); // створити кнопку
            but.Text = "Close"; // задати текст на кнопці
            form.Controls.Add(but); // додати кнопку до форми
            but.Location = new System.Drawing.Point(20, 20); // вказуємо координати для розміщення кнопки на формі
            but.MouseClick += But_MouseClick; // додаємо обробник події натискання на кнопку курсором миші

            //form.Show(); //відображає форму
            //form.ShowDialog(); //завантажує форму, як модальне діалогове вікно
            */

            Application.Run(new Form1());
        }

        // метод для обробки події при натисненні на кнопку курсором миші
        private static void But_MouseClick(object sender, MouseEventArgs e)
        {
            Button but = sender as Button; //приводемо object до Button
            if (but.BackColor == System.Drawing.Color.Yellow)
            {
                but.BackColor = System.Drawing.Color.Red;
            }
            else
            {
                but.BackColor = System.Drawing.Color.Yellow;
            }

            // для закриття форми
            /*
            Form form = (Form)but.Parent;
            form.Close();
             * */
        }
    }
}