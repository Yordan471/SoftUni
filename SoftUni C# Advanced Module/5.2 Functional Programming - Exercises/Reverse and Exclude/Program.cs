using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverse_and_Exclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(number => int.Parse(number))
                .ToList();

            Func<List<int>, List<int>> reverse = numberss =>
            {
                List<int> result = new List<int>();

                for (int i = numbers.Count - 1; i >= 0; i--)
                {
                    result.Add(numbers[i]);
                }

                return result;
            };

            Func<List<int>, Predicate<int>, List<int>> excludeDivisible = (numberss, match) =>
            {
                List<int> result = new List<int>();

                foreach (int num in numbers)
                {
                    if (!match(num))
                    {
                        result.Add(num);
                    }
                }

                return result;
            };

            int divisible = int.Parse(Console.ReadLine());

            numbers = excludeDivisible(numbers, n => n % divisible == 0);
            numbers = reverse(numbers);

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
