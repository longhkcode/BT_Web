// See https://aka.ms/new-console-template for more information

public class Program
{
    public static void Main()
    {
        int count = 0;
        int num = 2;
        while (count <= 20)
        {
            if (checkSNT(num))
            {
                Console.Write(num + " ");
                count++;
            }

            num++;
        }
    }

    public static bool checkSNT(int n)
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