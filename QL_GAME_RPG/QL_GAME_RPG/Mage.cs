namespace QL_GAME_RPG;

public class Mage : Character
{
    public int Mana{ get; set; }
    public int MagicDamage{ get; set; }
    public Mage() { }

    public Mage(int id, string name, int level, double hp, int mana, int magicDamage) : base(id, name, level, hp)
    {
        Mana = mana;
        MagicDamage = magicDamage;
    }

    public override void Input()
    {
        base.Input();
        Console.Write("Mana :  ");
        Mana =  Convert.ToInt32(Console.ReadLine());
        Console.Write("Magic Damage : ");
        MagicDamage = Convert.ToInt32(Console.ReadLine());
    }

    public override void DisPlay()
    {
        base.DisPlay();
        Console.WriteLine("Mana :  " + Mana);
        Console.WriteLine("Magic Damage : " + MagicDamage);
        Console.WriteLine("Power : " + GetPower());
    }

    public override int GetPower()
    {
        return level * MagicDamage;
    }
}