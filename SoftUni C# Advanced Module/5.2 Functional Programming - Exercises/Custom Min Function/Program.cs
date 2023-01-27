using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Min_Function
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] integers = Console.ReadLine()
                .Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(number => int.Parse(number))
                .ToArray();

            Func<int[], int> minNumber = numbers =>
            {
                int smallestNumber = 10000;

                foreach (int number in numbers)
                {
                    if (number < smallestNumber)
                    {
                        smallestNumber = number;
                    }
                }

                return smallestNumber;
            };

            Console.WriteLine(minNumber(integers));
        }
    }
}
