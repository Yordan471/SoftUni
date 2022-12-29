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
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            numbers = numbers
                .OrderByDescending(num => num)
                .Take(3)
                .ToArray();

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
