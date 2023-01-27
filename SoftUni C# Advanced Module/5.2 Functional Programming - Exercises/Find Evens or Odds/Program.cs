using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Find_Evens_or_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            int[] ranges = Console.ReadLine()
                .Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(range => int.Parse(range))
                .ToArray();

            int lowRange = ranges[0];
            int highRange = ranges[1];

            string oddOrEven = Console.ReadLine();
            List<int> numbers = new List<int>();

            Func<int, int, List<int>> numbersInRange = (firstRange, secondRange) =>
            {
                List<int> numsInRange = new List<int>();

                for (int range = lowRange; range < highRange; range++)
                {
                    numsInRange.Add(range);
                }

                return numsInRange;
            };

            numbers = numbersInRange(lowRange, highRange);

            Predicate<int> match = null;

            if (oddOrEven == "odd")
            {
                match = number => number % 2 == 1;
            }
            else if (oddOrEven == "even")
            {
                match = number => number % 2 == 0;
            }

            foreach (int num in numbers)
            {
                if (match(num))
                {
                    Console.Write($"{num} ");
                }
            }
        }
    }
}
