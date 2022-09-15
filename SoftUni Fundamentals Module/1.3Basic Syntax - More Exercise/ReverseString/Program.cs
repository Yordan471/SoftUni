using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            string reversedWord = "";

            for (int i = 0; i < word.Length; i++)
            {
                reversedWord += word[word.Length - i - 1];
            }

            Console.WriteLine(reversedWord);
        }
    }
}
