using System;
using System.Collections.Generic;
using System.Linq;

namespace Count_Real_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine()
                .Split(' ')
                .Select(x => double.Parse(x))
                .ToList();

            Dictionary <double, double> dict = new Dictionary<double, double>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (!dict.ContainsKey(numbers[i]))
                {
                    dict[numbers[i]] = 0;
                }

                dict[numbers[i]] += 1;
            }

            foreach (var d in dict.OrderBy(c => c.Key))
            {
                Console.WriteLine($"{d.Key} -> {d.Value}");
            }
        }
    }
}
