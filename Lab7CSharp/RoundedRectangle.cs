using System;
using System.Drawing;

public class RoundedRectangle : Figure
{
    public RoundedRectangle(int x, int y, int size, Color color)
        : base(x, y, size, color) { }

    public override void Draw(Graphics g)
    {
        using (Brush brush = new SolidBrush(color))
        {
            g.FillRectangle(brush, x, y, size, size);
        }
    }
}
