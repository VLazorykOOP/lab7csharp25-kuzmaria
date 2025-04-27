using System;
using System.Drawing;
using System.Windows.Forms;

namespace SincFunctionGraph
{
    public partial class Form2 : Form
    {
        private Graphics g;
        private Pen graphPen = new Pen(Color.Blue, 2);
        private Font labelFont = new Font("Arial", 12);
        private Brush labelBrush = Brushes.Black;

        private float x = 0f;
        private float step = 0.01f; // маленький крок для гладкості

        public Form2()
        {
            InitializeComponent();

            g = pictureBox1.CreateGraphics();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            x = 0f;
            g.Clear(Color.White);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (x > 4f)
            {
                timer1.Stop();
                return;
            }

            float prevX = (x - step) * 100;
            float prevY = (float)(Math.Sin(x - step) / (x - step)) * 100;

            float currX = x * 100;
            float currY = (float)(Math.Sin(x) / x) * 100;

            if (x - step == 0) prevY = 1 * 100; // окрема обробка нуля

            // Центр малювання посередині PictureBox
            int centerX = pictureBox1.Width / 2;
            int centerY = pictureBox1.Height / 2;

            g.DrawLine(graphPen,
                centerX + prevX, centerY - prevY,
                centerX + currX, centerY - currY);

            x += step;
        }

        private void buttonFont_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                labelFont = fontDialog1.Font;
                labelBrush = new SolidBrush(fontDialog1.Color);
                RedrawLabels();
            }
        }

        private void RedrawLabels()
        {
            g.Clear(Color.White);
            g.DrawString("y = sin(x) / x", labelFont, labelBrush, 10, 10);
        }
    }
}
