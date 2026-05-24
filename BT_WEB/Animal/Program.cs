// See https://aka.ms/new-console-template for more information

namespace Animal;
using System;

class Program
{
    public static void Main(string[] args)
    {
        Cat cat = new Cat("20kg", "1.5", "kitty");
        cat.PrintInfo();
    }
}
