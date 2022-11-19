using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Min_Max_Sum_Avrg
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            List<int> ints = new List<int>();

            for (int i = 0; i < number; i++)
            {
                int numbers = int.Parse(Console.ReadLine());

                ints.Add(numbers);
            }

            Console.WriteLine($"Sum = {ints.Sum()}");
            Console.WriteLine($"Min = {ints.Min()}");
            Console.WriteLine($"Max = {ints.Max()}");
            Console.WriteLine($"Average = {ints.Average()}");
        }
    }
}
