public class Program
{
	public static void Main(String[] args)
	{
		int year;
		bool isLeapYear = false;
		
		Console.Write("Enter year: ");
		year = Convert.ToInt32(Console.ReadLine());
		
		bool isDivisibleBy4 = year % 4 == 0;
		if (isDivisibleBy4)
		{
			bool isDivisible100 =  year % 100 == 0;
			if (isDivisible100)
			{
				bool isDivisible400 =  year % 400 == 0;
				{
					isLeapYear = true;
				}
			}else{
				isLeapYear = true;
			}
		}

		if (isLeapYear)
		{
			Console.WriteLine("{0} is a leap year", year);
		}
		else
		{
			Console.WriteLine("{0} is NOT a leap year", year);
		}
	}
}