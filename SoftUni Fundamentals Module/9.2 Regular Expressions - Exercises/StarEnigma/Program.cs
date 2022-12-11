using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace StarEnigma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfInput = int.Parse(Console.ReadLine());
            StringBuilder decryptedMessage = new StringBuilder();
            List<string> decryptedInfo = new List<string>();

            for (int i = 0; i < numberOfInput; i++)
            {
                string cryptedMessage = Console.ReadLine();

                int countLetters = 0;

                foreach (char ch in cryptedMessage)
                {
                    if (ch == 's' || ch == 'S' || ch == 't' ||
                        ch == 'T' || ch == 'a' || ch == 'A' ||
                        ch == 'r' || ch == 'R')
                    {
                        countLetters++;
                    }
                }

                foreach (char ch in cryptedMessage)
                {
                    int letter = ch;
                    letter -= countLetters;
                    decryptedMessage.Append((char)letter);
                }

                decryptedInfo.Add(decryptedMessage.ToString());
                countLetters = 0;
                decryptedMessage.Clear();
            }

            string pattern = @"@(?<planet>[A-Z][a-z]+)\d?([^@\-!:>])*:(?<planetPopulation>\d+)([^@\-!:>])*!(?<attackType>[A-Z])!([^@\-!:>])*->(?<soldierCount>\d+)";

            Regex regex = new Regex(pattern);
            Dictionary<string, List<string>> nameAndAttackType = new Dictionary<string, List<string>>();

            foreach (string info in decryptedInfo)
            {
                Match match = regex.Match(info);

                if (match.Success)
                {
                    string planetName = match.Groups["planet"].Value;
                    string attackType = match.Groups["attackType"].Value;

                    if (!nameAndAttackType.ContainsKey(attackType))
                    {
                        nameAndAttackType.Add(attackType, new List<string>());
                    }

                    nameAndAttackType[attackType].Add(planetName);
                }
            }

            if (!nameAndAttackType.ContainsKey("A"))
            {
                Console.WriteLine($"Attacked planets: 0");
            }

            if (nameAndAttackType.ContainsKey("A") || nameAndAttackType.ContainsKey("D"))
            {
                foreach (KeyValuePair<string, List<string>> name in nameAndAttackType
                    .OrderBy(x => x.Key)
                    .ThenBy(x => x.Value))
                {
                    if (name.Key == "A")
                    {
                        Console.WriteLine($"Attacked planets: {name.Value.Count()}");
                    }
                    else
                    {
                        Console.WriteLine($"Destroyed planets: {name.Value.Count()}");
                    }

                    name.Value.Sort();

                    foreach (string value in name.Value)
                    {
                        Console.WriteLine($"-> {value}");
                    }
                }
            }
         
            if (!nameAndAttackType.ContainsKey("D"))
            {
                Console.WriteLine($"Destroyed planets: 0");
            }
        }
    }
}
