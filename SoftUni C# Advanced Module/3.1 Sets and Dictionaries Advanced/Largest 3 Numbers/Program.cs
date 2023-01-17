using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Largest_3_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            inputNumbers = inputNumbers
                .OrderByDescending(num => num)
                .Take(3)
                .ToArray();

            Console.WriteLine(string.Join(" ", inputNumbers));
        }
    }
}
