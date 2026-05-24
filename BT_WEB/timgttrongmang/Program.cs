// See https://aka.ms/new-console-template for more information
string[] students = {"Christian", "Michael", "Camila", "Sienna", "Tanya", "Connor", "Zachariah", "Mallory", "Zoe", "Emily"};
Console.WriteLine("Enter a name’s student:");
string input_name = Console.ReadLine();
bool isExist = false;
for (int i = 0; i < students.Length; i++)
{
    if (students[i].Equals(input_name))
    {
        Console.WriteLine("Position of the students in the list " + input_name + " is: " + (i + 1));
        isExist = true;
        break;
    }
}

if (!isExist)
{
    Console.WriteLine("Not found" + input_name + " in the list.");
}