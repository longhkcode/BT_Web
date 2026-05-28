// See https://aka.ms/new-console-template for more information

using QL_GAME_RPG;

class Program
{
    public static void Main(string[] args)
    {
        GameManager gameManager = new GameManager();
        string filepath = "characters.txt";
        gameManager.LoadFromFile();
        while (true)
        {
            Console.WriteLine("========= GAME CHARACTER MANAGER =========");
            Console.WriteLine("1. Add Character");
            Console.WriteLine("2. Show Character List");
            Console.WriteLine("3. Find Character By ID");
            Console.WriteLine("4. Sort By Power");
            Console.WriteLine("5. Save To File");
            Console.WriteLine("6. Load From File");
            Console.WriteLine("7. Exit");
            Console.WriteLine("==========================================");
            
            Console.Write("Choose an option: ");
            int choose = Convert.ToInt32(Console.ReadLine());

            switch (choose)
            {
                case 1:
                    gameManager.AddCharacter();
                    break;
                case 2:
                    gameManager.ShowCharacters();
                    break;
                case 3:
                    gameManager.FindCbyID(Convert.ToInt32(Console.ReadLine()));
                    break;
                case 4:
                    gameManager.SortByPower();
                    break;
                case 5:
                    gameManager.SaveToFile(filepath);
                    break;
                case 6:
                    gameManager.LoadFromFile();
                    break;
                case 7:
                    Console.WriteLine("Exit");
                    return;
                default:
                    Console.WriteLine("Invalid option");
                    return;
            }
        }
    }
}