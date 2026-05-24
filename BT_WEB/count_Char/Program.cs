// See https://aka.ms/new-console-template for more information

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Nhap chuoi: ");
        string str = Console.ReadLine();

        Console.Write("Nhap ky tu can dem: ");
        char character = char.Parse(Console.ReadLine());

        int count = 0;

        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] == character)
            {
                count++;
            }
        }

        Console.WriteLine("So lan xuat hien cua ky tu '" + character + "' la: " + count);
    }
}