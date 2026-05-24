namespace circle_cy;
using System;

public class Circle
{
    private double radius = 1.0;
    private string color = "red";

    // Constructor mặc định
    public Circle()
    {
    }

    // Constructor với radius
    public Circle(double radius)
    {
        this.radius = radius;
    }

    // Constructor đầy đủ
    public Circle(double radius, string color)
    {
        this.radius = radius;
        this.color = color;
    }

    // Getter và Setter radius
    public double GetRadius()
    {
        return radius;
    }

    public void SetRadius(double radius)
    {
        this.radius = radius;
    }

    // Getter và Setter color
    public string GetColor()
    {
        return color;
    }

    public void SetColor(string color)
    {
        this.color = color;
    }

    // Tính diện tích
    public double GetArea()
    {
        return radius * radius * Math.PI;
    }

    // ToString
    public override string ToString()
    {
        return "Circle[radius=" + radius
                                + ", color=" + color + "]";
    }
}