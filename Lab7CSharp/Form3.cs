using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab7CSharp
{
    public partial class Form3 : Form
    {
        private Figure[] figures;
        private Random rand = new Random();
        private bool figuresCreated = false; // Флаг, що показує, чи створено фігури

        // Тепер зберігаємо вибраний тип фігури і колір
        private Type selectedFigureType;
        private Color selectedColor = Color.Black;
        private int selectedSize;

        public Form3()
        {
            InitializeComponent();
        }

        // Обробник для кнопки створення фігур
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            // Перевірка введеного розміру
            if (!int.TryParse(textBoxSize.Text, out selectedSize) || selectedSize <= 0)
            {
                MessageBox.Show("Будь ласка, введіть дійсне число для розміру фігури.");
                return;
            }

            // Перевірка вибору типу фігури
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Будь ласка, виберіть тип фігури.");
                return;
            }

            // Створення Bitmap для відображення фігур
            Bitmap bmp = new Bitmap(pictureBox2.Width, pictureBox2.Height);

            // Встановлення типу фігури з ComboBox
            switch (comboBox1.SelectedIndex)
            {
                case 0: // Коло
                    selectedFigureType = typeof(Circle);
                    break;
                case 1: // Прямокутник
                    selectedFigureType = typeof(RoundedRectangle);
                    break;
                case 2: // Ромб
                    selectedFigureType = typeof(Rhombus);
                    break;
                case 3: // Дуга
                    selectedFigureType = typeof(ArcShape);
                    break;
            }

            // Створення фігури з вибраним типом
            figures = new Figure[1]; // Для цього випадку створюємо одну фігуру
            figures[0] = CreateFigure(selectedFigureType, selectedSize, selectedColor);

            // Малювання фігур після їх створення
            DrawFigures(bmp);
            figuresCreated = true;
        }

        // Метод для створення фігури
        private Figure CreateFigure(Type figureType, int size, Color color)
        {
            int x = rand.Next(pictureBox2.Width - size);
            int y = rand.Next(pictureBox2.Height - size);

            // Створюємо фігуру відповідно до типу
            if (figureType == typeof(Circle))
                return new Circle(x, y, size, color);
            else if (figureType == typeof(RoundedRectangle))
                return new RoundedRectangle(x, y, size, color);
            else if (figureType == typeof(Rhombus))
                return new Rhombus(x, y, size, color);
            else if (figureType == typeof(ArcShape))
                return new ArcShape(x, y, size, color);
            else
                return null;
        }

        // Обробник для кнопки переміщення фігур
        private void buttonMove_Click(object sender, EventArgs e)
        {
            if (!figuresCreated)
            {
                MessageBox.Show("Спочатку створіть фігури!");
                return;
            }

            // Переміщення фігур випадковим чином
            foreach (var fig in figures)
            {
                fig.Move(rand.Next(-5, 5), rand.Next(-5, 5));
            }

            // Оновлення малюнка
            Bitmap bmp = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            DrawFigures(bmp);
        }

        private void DrawFigures(Bitmap bmp)
        {
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);

                // Малювання всіх фігур
                foreach (var fig in figures)
                {
                    fig.Draw(g);
                }
            }

            pictureBox2.Image = bmp;
        }

        private void textBoxSize_TextChanged(object sender, EventArgs e)
        {
            // Перевірка, чи введено число в TextBox
            if (!int.TryParse(textBoxSize.Text, out int size))
            {
                MessageBox.Show("Будь ласка, введіть дійсне число для розміру фігури.");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Тут ви можете обробляти вибір фігури з ComboBox
            // Наприклад, вивести тип вибраної фігури
            string selectedFigure = comboBox1.SelectedItem.ToString();
            MessageBox.Show($"Вибрано: {selectedFigure}");
        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            // Вибір кольору для фігури
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                selectedColor = colorDialog1.Color; // Збереження вибраного кольору
                MessageBox.Show($"Вибрано колір: {selectedColor}");
            }
        }
    }
}
