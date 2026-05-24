// See https://aka.ms/new-console-template for more information
namespace Fan;
class Program
{
    static void Main(string[] args)
    {
        Fan fan1 = new Fan();
        fan1.Speed = Fan.FAST;
        fan1.Radius = 10;
        fan1.Color = "yellow";
        fan1.On = true;

        Fan fan2 = new Fan();
        fan2.Speed = Fan.MEDIUM;
        fan2.Radius = 5;
        fan2.Color = "blue";
        fan2.On = false;

        Console.WriteLine("Fan 1:");
        Console.WriteLine(fan1.ToString());

        Console.WriteLine();

        Console.WriteLine("Fan 2:");
        Console.WriteLine(fan2.ToString());
    }
}