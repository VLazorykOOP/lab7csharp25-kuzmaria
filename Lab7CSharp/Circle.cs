using System;
using System.Drawing;

public class Circle : Figure
{
    public Circle(int x, int y, int size, Color color)
        : base(x, y, size, color) { }

    public override void Draw(Graphics g)
    {
        using (Brush brush = new SolidBrush(color))
        {
            g.FillEllipse(brush, x, y, size, size);
        }
    }
}
