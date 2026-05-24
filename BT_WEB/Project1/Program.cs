// See https://aka.ms/new-console-template for more information

namespace Project1;
using System;

class AbstractAndInterfaceTests
{
    static void Main(string[] args)
    {
        // Kiểm thử Animal
        Animal[] animals = new Animal[2];
        animals[0] = new Tiger();
        animals[1] = new Chicken();

        foreach (Animal animal in animals)
        {
            Console.WriteLine(animal.MakeSound());

            if (animal is Chicken)
            {
                Edible edible = (Chicken)animal;
                Console.WriteLine(edible.HowToEat());
            }
        }

        Console.WriteLine("-------------------");

        // Kiểm thử Fruit
        Fruit[] fruits = new Fruit[2];
        fruits[0] = new Orange();
        fruits[1] = new Apple();

        foreach (Fruit fruit in fruits)
        {
            Console.WriteLine(fruit.HowToEat());
        }
    }
}