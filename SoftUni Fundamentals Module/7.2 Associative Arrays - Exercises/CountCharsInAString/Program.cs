using System;
using System.Collections.Generic;
using System.Linq;

namespace CountCharsInAString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine()
                .Split(' ')
                .ToArray();

            Dictionary<char, int> charsCount = new Dictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                char[] textToChar = text[i].ToCharArray();

                for (int j = 0; j < text[i].Length; j++)
                {
                    if (!charsCount.ContainsKey(textToChar[j]))
                    {
                        charsCount.Add(textToChar[j], 0);
                    }

                    charsCount[textToChar[j]]++;
                }         
            }

            foreach (var charectar in charsCount)
            {
                Console.WriteLine($"{charectar.Key} -> {charectar.Value}");
            }
        }
    }
}
