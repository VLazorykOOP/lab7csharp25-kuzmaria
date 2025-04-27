using System;
using System.Drawing;

public abstract class Figure
{
    protected int x, y, size;
    protected Color color;

    public Figure(int x, int y, int size, Color color)
    {
        this.x = x;
        this.y = y;
        this.size = size;
        this.color = color;
    }

    // Віртуальна функція для малювання фігури
    public abstract void Draw(Graphics g);

    // Функція для переміщення фігури
    public void Move(int dx, int dy)
    {
        x += dx;
        y += dy;
    }
}
