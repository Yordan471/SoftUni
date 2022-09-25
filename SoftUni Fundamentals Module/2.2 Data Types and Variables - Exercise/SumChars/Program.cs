using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumChars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int sumLetters = 0;

            for (int i = 1; i <= n; i++)
            {
                char letter = char.Parse(Console.ReadLine());

                sumLetters += letter;
            }

            Console.WriteLine($"The sum equals: {sumLetters}");
        }
    }
}
