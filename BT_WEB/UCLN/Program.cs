public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Nhap vao so thu nhat : ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Nhap vao so thu hai : ");
        int b = int.Parse(Console.ReadLine());

        int ucln = (int) GCD(a, b);
        Console.WriteLine("GCD({0},{1}) = {2}",a,b,ucln);
    }

    public static long GCD(long a, long b)
    {
        if(b == 0) {
            return a;
        }
        return GCD(b, a%b);
    }
}