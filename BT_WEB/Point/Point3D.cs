namespace Point;

using System;

public class Point3D : Point2D
{
    private float z = 0.0f;

    // Constructor mặc định
    public Point3D()
    {
    }

    // Constructor có tham số
    public Point3D(float x, float y, float z)
        : base(x, y)
    {
        this.z = z;
    }
    
    public float GetZ()
    {
        return z;
    }

    public void SetZ(float z)
    {
        this.z = z;
    }
    
    public void SetXYZ(float x, float y, float z)
    {
        SetXY(x, y);
        this.z = z;
    }

    public float[] GetXYZ()
    {
        return new float[]
        {
            GetX(),
            GetY(),
            z
        };
    }

    public override string ToString()
    {
        return "("
               + GetX() + ","
               + GetY() + ","
               + z + ")";
    }
}