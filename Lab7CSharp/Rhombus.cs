using System;
using System.Drawing;

public class Rhombus : Figure
{
    public Rhombus(int x, int y, int size, Color color)
        : base(x, y, size, color) { }

    public override void Draw(Graphics g)
    {
        using (Brush brush = new SolidBrush(color))
        {
            Point[] points = {
                new Point(x + size / 2, y),
                new Point(x + size, y + size / 2),
                new Point(x + size / 2, y + size),
                new Point(x, y + size / 2)
            };
            g.FillPolygon(brush, points);
        }
    }
}
