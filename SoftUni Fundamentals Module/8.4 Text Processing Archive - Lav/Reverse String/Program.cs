using System;
using System.Linq;

namespace Reverse_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            char[] reverseWord = word.ToCharArray();
            Array.Reverse(reverseWord);

            Console.WriteLine(new string(reverseWord));           
        }
    }
}
