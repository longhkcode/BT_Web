// See https://aka.ms/new-console-template for more information
    int dem = 0;
    Console.WriteLine("Danh sach so nguyen to :");
    for (int i = 2; i <= 100; i++)
    {
        for (int j = 1; j <= i; j++)
        {
            if (i % j == 0)
            {
                dem++;
            }
        }

        if (dem == 2)
        {
            Console.WriteLine(i);
        }
        dem = 0;
    }