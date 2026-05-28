namespace QL_GAME_RPG;

public class Character
{
    public int id{ get; set; }
    public string name{ get; set; }
    public int level { get; set; }
    public double hp{ get; set; }

    public Character() { }
    public Character(int id, string name, int level, double hp)
    {
        this.id = id;
        this.name = name;
        this.level = level;
        this.hp = hp;
    }

    public virtual void Input()
    {
        Console.Clear();
        Console.Write("ID : ");
        this.id = Convert.ToInt32(Console.ReadLine());
        Console.Write("Name : ");
        this.name = Console.ReadLine();
        Console.Write("Level : ");
        this.level = Convert.ToInt32(Console.ReadLine());
        Console.Write("HP : ");
        this.hp = Convert.ToInt32(Console.ReadLine());
    }

    public virtual void DisPlay()
    {
        Console.WriteLine("========Player========");
        Console.WriteLine("Id: " + id);
        Console.WriteLine("Name: " + name);
        Console.WriteLine("Level: " +level);
        Console.WriteLine("HP: " + hp);
    }
    
    public virtual int GetPower()
    {
        return 0;
    }

}