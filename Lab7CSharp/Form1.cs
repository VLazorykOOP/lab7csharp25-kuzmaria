using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab7CSharp
{
    public partial class Form1 : Form
    {
        private Random random = new Random(); // Генератор випадкових чисел

        public Form1()
        {
            InitializeComponent();

            // Заповнюємо ComboBox варіантами фігур
            comboBox1.Items.AddRange(new string[] { "Точка", "Коло", "Квадрат" });
            comboBox1.SelectedIndex = 0; // За замовчуванням обрана перша
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Можна залишити порожнім або видалити, якщо не використовується
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Можна залишити порожнім або налаштувати ініціалізацію при завантаженні форми
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int size;

            // Перевірка коректності введення числа
            if (!int.TryParse(textBox1.Text, out size) || size <= 0)
            {
                MessageBox.Show("Будь ласка, введіть коректний розмір (додатнє число).");
                return;
            }

            // Створюємо нове зображення для PictureBox
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White); // Очищення фону

                // Випадкові координати
                int x = random.Next(pictureBox1.Width - size);
                int y = random.Next(pictureBox1.Height - size);

                // Випадковий колір
                Color randomColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
                Brush brush = new SolidBrush(randomColor);

                // Який саме примітив малювати
                string selectedShape = comboBox1.SelectedItem.ToString();

                if (selectedShape == "Точка")
                {
                    g.FillRectangle(brush, x, y, 1, 1);
                }
                else if (selectedShape == "Коло")
                {
                    g.FillEllipse(brush, x, y, size, size);
                }
                else if (selectedShape == "Квадрат")
                {
                    g.FillRectangle(brush, x, y, size, size);
                }
            }

            // Показуємо нове зображення в PictureBox
            pictureBox1.Image = bmp;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Нічого робити не потрібно, якщо клік по PictureBox не обробляється
        }
    }
}
