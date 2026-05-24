// See https://aka.ms/new-console-template for more information

using System;
namespace Point;
class Program
{
    static void Main(string[] args)
    {
        
        Point2D p1 = new Point2D();
        Console.WriteLine(p1);

        Point2D p2 = new Point2D(2.5f, 3.7f);
        Console.WriteLine(p2);

        p2.SetXY(5.5f, 6.6f);

        float[] arr = p2.GetXY();

        Console.WriteLine("x = " + arr[0]);
        Console.WriteLine("y = " + arr[1]);

        Console.WriteLine(p2);
        
        
        Point3D p3 = new Point3D();
        Console.WriteLine(p3);

        Point3D p4 = new Point3D(1.1f, 2.2f, 3.3f);
        Console.WriteLine(p4);

        p4.SetXYZ(7.7f, 8.8f, 9.9f);

        float[] xyz = p4.GetXYZ();

        Console.WriteLine("x = " + xyz[0]);
        Console.WriteLine("y = " + xyz[1]);
        Console.WriteLine("z = " + xyz[2]);

        Console.WriteLine(p4);
    }
}