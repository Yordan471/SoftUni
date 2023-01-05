using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum_Numbers
{
    public delegate int Aggregate(int a, int b);

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] lineOfIntegers = Console.ReadLine()
                .Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(num => int.Parse(num))
                .ToArray();

            Console.WriteLine(lineOfIntegers.Length);
            Console.WriteLine(lineOfIntegers.Sum());

        }
    }
}
