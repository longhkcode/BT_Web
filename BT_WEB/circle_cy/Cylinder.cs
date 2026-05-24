namespace circle_cy;

using System;

public class Cylinder : Circle
{
    private double height = 1.0;

    // Constructor mặc định
    public Cylinder()
    {
    }

    // Constructor với radius
    public Cylinder(double radius)
        : base(radius)
    {
    }

    // Constructor với radius và height
    public Cylinder(double radius, double height)
        : base(radius)
    {
        this.height = height;
    }

    // Constructor đầy đủ
    public Cylinder(double radius, double height, string color)
        : base(radius, color)
    {
        this.height = height;
    }

    // Getter và Setter height
    public double GetHeight()
    {
        return height;
    }

    public void SetHeight(double height)
    {
        this.height = height;
    }

    // Tính thể tích
    public double GetVolume()
    {
        return GetArea() * height;
    }

    // Diện tích toàn phần hình trụ
    public double GetCylinderArea()
    {
        double radius = GetRadius();

        return 2 * Math.PI * radius * height
               + 2 * Math.PI * radius * radius;
    }

    // ToString
    public override string ToString()
    {
        return "Cylinder["
               + base.ToString()
               + ", height=" + height + "]";
    }
}