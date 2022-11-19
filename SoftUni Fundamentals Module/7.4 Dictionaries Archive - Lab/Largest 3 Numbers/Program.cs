using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Largest_3_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine()
                .Split(' ')
                .Select(x => double.Parse(x))
                .OrderByDescending(x => x)
                .Take(3)
                .ToList();

            Console.Write(string.Join(' ', numbers));

        }
    }
}
