namespace Point;

using System;

public class Point2D
{
    private float x = 0.0f;
    private float y = 0.0f;

    // Constructor mặc định
    public Point2D()
    {
    }

    // Constructor có tham số
    public Point2D(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    // Getter và Setter cho x
    public float GetX()
    {
        return x;
    }

    public void SetX(float x)
    {
        this.x = x;
    }

    // Getter và Setter cho y
    public float GetY()
    {
        return y;
    }

    public void SetY(float y)
    {
        this.y = y;
    }

    // Set cả x và y
    public void SetXY(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    // Trả về mảng [x,y]
    public float[] GetXY()
    {
        return new float[] { x, y };
    }

    // ToString
    public override string ToString()
    {
        return "(" + x + "," + y + ")";
    }
}