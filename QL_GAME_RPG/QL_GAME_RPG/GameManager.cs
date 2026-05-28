namespace QL_GAME_RPG;

public class GameManager
{
    public List<Character> characters = new List<Character>();
    public string filepath = "characters.txt";
    public void AddCharacter()
    {
        Console.WriteLine("Adding character");
        Console.WriteLine("Choose 1 : Warrior &&  2 : Mage");
        int type = Convert.ToInt32(Console.ReadLine());
        Character c = null;
        if (type == 1)
        {
            Console.WriteLine("Choose 1 : Warrior");
            c = new Warrior();
        }else if (type == 2)
        {
            Console.WriteLine("Choose 2 : Mage");
            c = new Mage();
        }
        else
        {
            Console.WriteLine("You need choose 1 or 2 to start");
            return;
        }
        c.Input();
        if (characters.Exists(x => x.id == c.id))
        {
            Console.WriteLine($" ID '{c.id}' da ton tai! Khong the them nhan vat.");
            return;
        }
        characters.Add(c);
    }
    
    public void ShowCharacters()
    {
        if (characters.Count == 0)
        {
            Console.WriteLine("Character list is empty!"); 
            return;
        }
        foreach (Character c in characters)
        {
            c.DisPlay();
        }
    }

    public void FindCbyID(int id)
    {
        foreach (Character c in characters)
        {
            if (c.id == id)
            {
                c.DisPlay();
            }
        }
    }

    public int ComparePower(Character a, Character b)
    {
        return b.GetPower().CompareTo(a.GetPower());
    }

    public void SortByPower()
    {
        characters.Sort(ComparePower);

        ShowCharacters();
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Character c in characters)
            {
                if (c is Warrior w)
                {
                    writer.WriteLine($"Warrior|{w.id}|{w.name}|{w.level}|{w.hp}|{w.AttackDamage}|{w.Weapon}");
                }else if (c is Mage m)
                {
                    writer.WriteLine($"Mage|{m.id}|{m.name}|{m.level}|{m.hp}|{m.Mana}|{m.MagicDamage}");
                }
            }
        }
    }

    public void LoadFromFile()
    {
        if (!File.Exists(filepath))
        {
            Console.WriteLine("File not found!");
            return;
        }
        characters.Clear();
        string[] lines = File.ReadAllLines(filepath);
        foreach (string line in lines)
        {
            string[] data = line.Split('|');
            
            if (data[0] == "Warrior")
            {
                Warrior w = new Warrior(
                    int.Parse(data[1]),                 
                    data[2],                 
                    int.Parse(data[3]),     
                    int.Parse(data[4]),    
                    int.Parse(data[5]),   
                    data[6]  
                );

                characters.Add(w);
            }
            else if (data[0] == "Mage")
            {
                Mage m = new Mage(
                    int.Parse(data[1]),                 
                    data[2],                 
                    int.Parse(data[3]),   
                    int.Parse(data[4]),      
                    int.Parse(data[5]),     
                    int.Parse(data[6])       
                );

                characters.Add(m);
            }
        }
    }
}