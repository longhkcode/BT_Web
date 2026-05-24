// See https://aka.ms/new-console-template for more information

using System;

class Program
{
    static void Main(string[] args)
    {
        int[] array = new int[10];

        Console.Write("Nhap so phan tu cua mang: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.Write("Nhap phan tu thu " + i + ": ");
            array[i] = int.Parse(Console.ReadLine());
        }

        Console.Write("Nhap phan tu can xoa: ");
        int X = int.Parse(Console.ReadLine());

        int index_del = -1;

        for (int i = 0; i < n; i++)
        {
            if (array[i] == X)
            {
                index_del = i;
                break;
            }
        }

        if (index_del == -1)
        {
            Console.WriteLine("Phan tu khong ton tai trong mang!");
        }
        else
        {
            for (int i = index_del; i < n - 1; i++)
            {
                array[i] = array[i + 1];
            }

            n--;

            Console.WriteLine("Mang sau khi xoa:");

            for (int i = 0; i < n; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
    }
}