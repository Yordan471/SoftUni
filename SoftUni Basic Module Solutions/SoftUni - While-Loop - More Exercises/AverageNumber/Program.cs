using System;

namespace AverageNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            int number = 0;
            int counter = 0;

            while (counter != n)
            {
                number = int.Parse(Console.ReadLine());
                counter++;

                sum += number;
            }
            double averageSum = sum * 1.0 / n;
            Console.WriteLine($"{averageSum:f2}");
        }
    }
}
