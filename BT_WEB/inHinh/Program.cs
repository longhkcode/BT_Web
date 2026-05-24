using System;

class Program
{
    static void Main()
    {
        int choice;

        do
        {
            // Hiển thị menu
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Print the rectangle");
            Console.WriteLine("2. Print the square triangle");
            Console.WriteLine("3. Print isosceles triangle");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    // In hình chữ nhật
                    Console.Write("Nhập chiều dài: ");
                    int length = int.Parse(Console.ReadLine());

                    Console.Write("Nhập chiều rộng: ");
                    int width = int.Parse(Console.ReadLine());

                    for (int i = 0; i < length; i++)
                    {
                        for (int j = 0; j < width; j++)
                        {
                            Console.Write("* ");
                        }
                        Console.WriteLine();
                    }
                    break;

                case 2:
                    Console.WriteLine("Các kiểu tam giác vuông:");
                    Console.WriteLine("1. Bottom-left");
                    Console.WriteLine("2. Top-left");
                    Console.WriteLine("3. Bottom-right");
                    Console.WriteLine("4. Top-right");
                    Console.Write("Chọn kiểu tam giác: ");

                    int type = int.Parse(Console.ReadLine());

                    switch (type)
                    {
                        case 1:
                            // Bottom-left
                            for (int i = 1; i <= 5; i++)
                            {
                                for (int j = 1; j <= i; j++)
                                {
                                    Console.Write("* ");
                                }
                                Console.WriteLine();
                            }
                            break;

                        case 2:
                            // Top-left
                            for (int i = 5; i >= 1; i--)
                            {
                                for (int j = 1; j <= i; j++)
                                {
                                    Console.Write("* ");
                                }
                                Console.WriteLine();
                            }
                            break;

                        case 3:
                            // Bottom-right
                            for (int i = 1; i <= 5; i++)
                            {
                                for (int j = 1; j <= 5 - i; j++)
                                {
                                    Console.Write("  ");
                                }

                                for (int j = 1; j <= i; j++)
                                {
                                    Console.Write("* ");
                                }

                                Console.WriteLine();
                            }
                            break;

                        case 4:
                            // Top-right
                            for (int i = 5; i >= 1; i--)
                            {
                                for (int j = 1; j <= 5 - i; j++)
                                {
                                    Console.Write("  ");
                                }

                                for (int j = 1; j <= i; j++)
                                {
                                    Console.Write("* ");
                                }

                                Console.WriteLine();
                            }
                            break;

                        default:
                            Console.WriteLine("Lựa chọn không hợp lệ!");
                            break;
                    }
                    break;

                case 3:
                    // In tam giác cân
                    Console.Write("Nhập chiều cao tam giác: ");
                    int h = int.Parse(Console.ReadLine());

                    for (int i = 1; i <= h; i++)
                    {
                        // In khoảng trắng
                        for (int j = 1; j <= h - i; j++)
                        {
                            Console.Write(" ");
                        }

                        // In dấu *
                        for (int j = 1; j <= 2 * i - 1; j++)
                        {
                            Console.Write("*");
                        }

                        Console.WriteLine();
                    }
                    break;

                case 4:
                    Console.WriteLine("Thoát chương trình!");
                    break;

                default:
                    Console.WriteLine("Lựa chọn không hợp lệ!");
                    break;
            }

            Console.WriteLine();

        } while (choice != 4);
    }
}