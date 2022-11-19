using System;
using System.Text.RegularExpressions;

namespace Post_Office
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string patternFirstWord = @"([#$*&])(?<firstWord>[A-Z]+)\1";

            string[] inputInfo = Console.ReadLine()
                .Split('|');

            string firstWord = inputInfo[0];
            string secondWord = inputInfo[1];
            string thirdWord = inputInfo[2];

            Regex regexFirstWord = new Regex(patternFirstWord);
            Match matchFrstWord = regexFirstWord.Match(firstWord);

            string capitalLetters = matchFrstWord.Groups["firstWord"].Value;

            for (int i = 0; i < capitalLetters.Length; i++)
            {
                char letter = capitalLetters[i];
                int letterToASCI = letter;

                string patternSecondWord = $@"{letterToASCI}:(?<length>[0-9][0-9])";
                Regex regexSecondWord = new Regex(patternSecondWord);
                Match matchSecondWord = regexSecondWord.Match(secondWord);

                int wordLength = int.Parse(matchSecondWord.Groups["length"].Value);

                string patternThirdWord = $@"(?<=\s|^){letter}[^\s]{wordLength}(?=\s|$)";
                Regex regexThirdWord = new Regex(patternThirdWord);
                Match matchThirdWord = regexThirdWord.Match(thirdWord);

                string word = matchThirdWord.ToString();

                Console.WriteLine(word);
            }
        }
    }
}
