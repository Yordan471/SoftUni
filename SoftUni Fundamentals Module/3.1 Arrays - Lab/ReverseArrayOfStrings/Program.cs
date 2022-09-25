using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseArrayOfStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');

            for (int i = input.Length - 1; i >= 0; i--)
            {
                Console.Write($"{input[i]} ");
            }
    //     Array.Reverse(input);
    //
    //     for (int i = 0; i < input.Length; i++)
    //     {
    //         Console.Write($"{input[i]} ");
    //     }
        }
    }
}
