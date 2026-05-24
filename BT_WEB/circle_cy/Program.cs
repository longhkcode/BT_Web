// See https://aka.ms/new-console-template for more information
using System;
namespace circle_cy;
class Program
{
    static void Main(string[] args)
    {
        Circle c1 = new Circle();
        Console.WriteLine(c1);

        Circle c2 = new Circle(5.0);
        Console.WriteLine(c2);

        Circle c3 = new Circle(2.5, "blue");
        Console.WriteLine(c3);

        Console.WriteLine("Area of c3 = " + c3.GetArea());
        
        
        Cylinder cy1 = new Cylinder();
        Console.WriteLine(cy1);

        Cylinder cy2 = new Cylinder(3.0);
        Console.WriteLine(cy2);

        Cylinder cy3 = new Cylinder(3.0, 5.0);
        Console.WriteLine(cy3);

        Cylinder cy4 = new Cylinder(2.5, 7.0, "green");
        Console.WriteLine(cy4);

        Console.WriteLine("Volume = " + cy4.GetVolume());
        Console.WriteLine("Surface Area = " + cy4.GetCylinderArea());
    }
}