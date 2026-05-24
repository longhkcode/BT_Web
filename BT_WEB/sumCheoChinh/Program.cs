// See https://aka.ms/new-console-template for more information
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Nhap kich thuoc ma tran vuong n = ");
        int n = int.Parse(Console.ReadLine());
        
        double[,] matrix = new double[n, n];
        Console.WriteLine("Nhap cac phan tu cua ma tran:");

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write("matrix[" + i + "][" + j + "] = ");
                matrix[i, j] = double.Parse(Console.ReadLine());
            }
        }
        double sum = 0;

        for (int i = 0; i < n; i++)
        {
            sum += matrix[i, i];
        }
        
        Console.WriteLine("\nMa tran vua nhap:");

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
        Console.WriteLine("\nTong cac phan tu tren duong cheo chinh = " + sum);
    }
}