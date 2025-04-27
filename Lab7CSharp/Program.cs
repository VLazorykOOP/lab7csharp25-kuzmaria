using SincFunctionGraph;
using System;
using System.Windows.Forms;

namespace Lab7CSharp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Створення основної форми
            Form mainForm = new Form();
            mainForm.Text = "Лабораторні роботи";
            mainForm.Width = 200; // Можна задати ширину форми
            mainForm.Height = 200; // Можна задати висоту форми

            // Створення кнопок для кожного завдання
            Button button1 = new Button() { Text = "Завдання 1", Left = 10, Top = 10, Width = 150 };
            Button button2 = new Button() { Text = "Завдання 2", Left = 10, Top = 50, Width = 150 };
            Button button3 = new Button() { Text = "Завдання 3", Left = 10, Top = 90, Width = 150 };

            // Обробники подій для кожної кнопки
            button1.Click += (s, e) =>
            {
                Form1 form1 = new Form1();
                if (form1 != null)
                {
                    form1.Show();
                }
                else
                {
                    MessageBox.Show("Форма 1 не ініціалізована.");
                }
            };

            button2.Click += (s, e) =>
            {
                Form2 form2 = new Form2();
                if (form2 != null)
                {
                    form2.Show();
                }
                else
                {
                    MessageBox.Show("Форма 2 не ініціалізована.");
                }
            };

            button3.Click += (s, e) =>
            {
                Form3 form3 = new Form3();
                if (form3 != null)
                {
                    form3.Show();
                }
                else
                {
                    MessageBox.Show("Форма 3 не ініціалізована.");
                }
            };

            // Додавання кнопок до основної форми
            mainForm.Controls.Add(button1);
            mainForm.Controls.Add(button2);
            mainForm.Controls.Add(button3);

            // Запуск програми
            Application.Run(mainForm);
        }
    }
}
