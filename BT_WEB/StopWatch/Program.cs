// See https://aka.ms/new-console-template for more information

namespace StopWatch;
class Program
{
    static void SelectionSort(int[] arr)
    {
        int n = arr.Length;

        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i;

            for (int j = i + 1; j < n; j++)
            {
                if (arr[j] < arr[minIndex])
                {
                    minIndex = j;
                }
            }

            int temp = arr[minIndex];
            arr[minIndex] = arr[i];
            arr[i] = temp;
        }
    }

    static void Main(string[] args)
    {
        int[] arr = new int[100000];
        Random random = new Random();

        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = random.Next(100000);
        }

        StopWatch stopWatch = new StopWatch();

        stopWatch.Start();

        SelectionSort(arr);

        stopWatch.Stop();

        Console.WriteLine("Thoi gian thuc thi: " + stopWatch.GetElapsedTime() + " milliseconds");
    }
}