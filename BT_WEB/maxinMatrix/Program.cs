// See https://aka.ms/new-console-template for more information
using System;

class Program
{
    static void Main(string[] args)
    {       
        Console.Write("Nhap so dong cua ma tran: ");
        int rows = int.Parse(Console.ReadLine());

        Console.Write("Nhap so cot cua ma tran: ");
        int cols = int.Parse(Console.ReadLine());
        
        double[,] matrix = new double[rows, cols];
        
        Console.WriteLine("Nhap cac phan tu cua ma tran:");

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write("matrix[" + i + "][" + j + "] = ");
                matrix[i, j] = double.Parse(Console.ReadLine());
            }
        }
        
        double max = matrix[0, 0];
        int rowIndex = 0;
        int colIndex = 0;
        
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                    rowIndex = i;
                    colIndex = j;
                }
            }
        }
        Console.WriteLine("\nPhan tu lon nhat trong ma tran la: " + max);
        Console.WriteLine("Toa do cua phan tu lon nhat: [" + rowIndex + "," + colIndex + "]");
    }
}