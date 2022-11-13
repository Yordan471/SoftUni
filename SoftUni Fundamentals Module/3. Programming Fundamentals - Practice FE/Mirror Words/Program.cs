using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Mirror_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string pattern = @"([@#]){1}(?<firstWord>[A-Za-z]{3,})\1{2}(?<secondWord>[A-Za-z]{3,})\1{1}";

            Regex regex= new Regex(pattern);

            MatchCollection matches = regex.Matches(text);

            int counter = 0;
            List<string> mirrorWords = new List<string>();

            foreach (Match match in matches)
            {
                counter++;

                string firstWord = match.Groups["firstWord"].Value;
                string secondWord = match.Groups["secondWord"].Value;
                string mirrorWord = string.Empty;

                char[] reversedWordChars = secondWord.ToCharArray();
                Array.Reverse(reversedWordChars);

                for (int i = 0; i < reversedWordChars.Length; i++)
                {
                    mirrorWord += reversedWordChars[i];
                }

                if (match.Success && firstWord == mirrorWord)
                {
                    mirrorWords.Add($"{firstWord} <=> {secondWord}");
                }
            }

            Console.WriteLine($"{counter} word pairs found!");

            if (mirrorWords.Count > 0 )
            {
                Console.WriteLine("The mirror words are:");
                Console.WriteLine(string.Join(", ", mirrorWords));
            }
            else
            {
                Console.WriteLine("No mirror words!");
            }          
        }
    }
}
