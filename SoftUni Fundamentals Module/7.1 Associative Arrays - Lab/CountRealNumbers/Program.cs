using System;
using System.Collections.Generic;
using System.Linq;

namespace CountRealNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            SortedDictionary<int, int> sortedIntegers = new SortedDictionary<int, int>();
            
            foreach (int number in numbers)
            {
                if (sortedIntegers.ContainsKey(number))
                {
                    sortedIntegers[number]++;
                }
                else
                {
                    sortedIntegers.Add(number, 1);
                }
            }

            foreach (KeyValuePair<int, int> number in sortedIntegers)
            {
                Console.WriteLine($"{number.Key} -> {number.Value}");
            }
        }
    }
}
