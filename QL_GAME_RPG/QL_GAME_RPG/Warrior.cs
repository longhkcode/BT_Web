namespace QL_GAME_RPG;

public class Warrior : Character
{
    public int AttackDamage { get; set; }
    public string Weapon{ get; set; }
    
    public Warrior() { }

    public Warrior(int id, string name, int level, double hp, int attackDamage, string weapon) : base(id, name, level, hp)
    {
        AttackDamage = attackDamage;
        Weapon = weapon;
    }

    public override void Input()
    {
        base.Input();
        Console.Write("AttackDamage :  ");
        AttackDamage =  Convert.ToInt32(Console.ReadLine());
        Console.Write("Weapon : ");
        Weapon = Console.ReadLine();
    }

    public override void DisPlay()
    {
        base.DisPlay();
        Console.WriteLine("AttackDamage : " + AttackDamage);
        Console.WriteLine("Weapon : " + Weapon);
        Console.WriteLine("Power : " + GetPower());
        
    }

    public override int GetPower()
    {
        return level * AttackDamage;
    }
}