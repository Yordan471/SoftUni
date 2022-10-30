using System;
using System.Linq;

namespace WordFilter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split()
                .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine,
                words.Where(word => word.Length % 2 == 0)));
        }
    }
}
