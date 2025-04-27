using System;
using System.Drawing;

public class ArcShape : Figure
{
    public ArcShape(int x, int y, int size, Color color)
        : base(x, y, size, color) { }

    public override void Draw(Graphics g)
    {
        using (Brush brush = new SolidBrush(color))
        {
            g.FillPie(brush, x, y, size, size, 0, 90); // Малюємо сектор кола
        }
    }
}
