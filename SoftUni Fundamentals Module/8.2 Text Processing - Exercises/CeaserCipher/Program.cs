using System;
using System.Linq;

namespace CeaserCipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] text = Console.ReadLine()
                .ToCharArray();

            for (int i = 0; i < text.Length; i++)
            {
                int number = text[i] + 3;
                text[i] = (char)number;
            }

            Console.WriteLine(text);
        }
    }
}
