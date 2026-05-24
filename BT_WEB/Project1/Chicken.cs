namespace Project1;

public class Chicken : Animal, Edible
{
    public override string MakeSound()
    {
        return "Chicken: cluck-cluck!";
    }

    public string HowToEat()
    {
        return "Chicken could be fried";
    }
}