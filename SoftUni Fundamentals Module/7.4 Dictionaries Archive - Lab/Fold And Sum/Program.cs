using System;
using System.Linq;
using System.Collections.Generic;

namespace Fold_And_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ')
                .Select(x => int.Parse(x))
                .ToList();

            int quarterLength = numbers.Count / 4;
            
            List<int> foldedNumbers = numbers
                .Skip(quarterLength * 3)
                .Reverse()
                .ToList();

            foldedNumbers = new List<int>(
                numbers
                .Take(quarterLength)
                .Reverse()
                .ToList()
                .Concat(foldedNumbers));

            numbers = numbers
                .Skip(quarterLength)
                .Take(quarterLength * 2)
                .ToList();

            List<int> result = new List<int>();

            for (int i = 0; i < quarterLength * 2; i++)
            {
                result.Add(numbers[i] + foldedNumbers[i]);
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
