public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Please enter a number: ");
        int n = Convert.ToInt32(Console.ReadLine());
        if (isSNT(n))
        {
            Console.WriteLine("{0} la SNT",n);
        }
        else
        {
            Console.WriteLine("{0} ko phai la SNT",n);
        }
    }

    public static bool isSNT(int n)
    {
        if (n <= 1) return false;
        for (int i = 2; i <= Math.Sqrt(n); i++)
        {
            if (n % i == 0)
            {
                return false;
            }
        }
        return true;
    }
}