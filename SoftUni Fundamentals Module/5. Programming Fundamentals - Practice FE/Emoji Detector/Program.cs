using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

namespace Emoji_Detector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string patternEmoji = @"([:]{2}|[*]{2})(?<emoji>[A-Z][a-z]{2,})\1";
            string patternNumbers = @"(?<number>[0-9])";

            Regex regexNumbers = new Regex(patternNumbers);

            MatchCollection matchesNumbers = regexNumbers.Matches(text);

            BigInteger bigInteger = new BigInteger(1);
            

            foreach (Match match in matchesNumbers)
            {
                char[] numbers = match.Groups["number"].Value.ToCharArray();

                for (int i = 0; i < numbers.Length; i++)
                {
                    int digit = int.Parse(numbers[i].ToString());
                    bigInteger *= digit; 
                }
            }

            Regex regexEmoji = new Regex(patternEmoji);

            MatchCollection matchesEmoji = regexEmoji.Matches(text);
            
            List<string> emojiToList = new List<string>();
            int countEmoji = 0;

            foreach (Match match in matchesEmoji)
            {
                string emoji = match.Groups["emoji"].Value;
                string symbols = match.Groups[1].Value;

                string emojiSymbols = symbols + emoji + symbols;
                char[] emojiToChars = emoji.ToCharArray();

                int score = 0;
                countEmoji++;

                for (int i = 0; i < emojiToChars.Length; i++)
                {
                    score += emojiToChars[i];
                }

                if (score > bigInteger)
                {
                    emojiToList.Add($"{emojiSymbols}-{score}");
                }
            }

            Console.WriteLine($"Cool threshold: {bigInteger}");

            if (countEmoji > 0)
            {
                Console.WriteLine($"{countEmoji} emojis found in the text. " +
                $"The cool ones are:");

                foreach (string emoji in emojiToList)
                {
                    Console.WriteLine($"{emoji.Split('-')[0]}");
                }
            }           
        }
    }
}
