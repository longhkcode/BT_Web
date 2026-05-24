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
        Console.Write("Nhap gia tri X can chen: ");
        int X = int.Parse(Console.ReadLine());

        // Nhập vị trí cần chèn
        Console.Write("Nhap vi tri index can chen: ");
        int index = int.Parse(Console.ReadLine());
        if (index < 0 || index > n || n >= array.Length)
        {
            Console.WriteLine("Khong chen duoc phan tu vao mang!");
        }
        else
        {
            for (int i = n; i > index; i--)
            {
                array[i] = array[i - 1];
            }
            array[index] = X;

            n++;
            Console.WriteLine("Mang sau khi chen:");
            for (int i = 0; i < n; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
    }
}