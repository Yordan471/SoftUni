using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Security;
using System.Text.RegularExpressions;

namespace Nether_Realms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string splitPattern = @"[,\s]+";

            List<string> inputInfo = Regex
                .Split(Console.ReadLine(), splitPattern)
                .OrderBy(x => x)
                .ToList();

            Dictionary <string, int> nameAndHealth = new Dictionary<string, int>();
            Dictionary <string, double> nameAndDamage = new Dictionary<string, double>();

            string patternHealth = @"(?<character>[^\+\-\*\/,.0-9])"; 
            Regex regexHealth = new Regex(patternHealth);

            string patternDamage = @"(?<damage>-?\d+\.?\d*)";
            Regex regexDamage = new Regex(patternDamage);

            string patternMultyDivide = @"(?<operator>[\/\*])";
            Regex regexMultyDivide = new Regex(patternMultyDivide);

            foreach (string input in inputInfo)
            {
                int sum = 0;
                MatchCollection matchesHealth = regexHealth.Matches(input);

                foreach (Match match in matchesHealth)
                {
                    char letter = char.Parse(match.Groups["character"].Value);
                    sum += (int)letter;                   
                }

                nameAndHealth[input] = sum;
            }

            foreach (string input in inputInfo)
            {
                double damage = 0.00;       

                MatchCollection matchesDamage = regexDamage.Matches(input);

                foreach (Match match in matchesDamage)
                {
                    double number = double.Parse(match.Groups["damage"].Value);
                    damage += number;
                }

                MatchCollection matchesMD = regexMultyDivide.Matches(input);

                foreach (Match match in matchesMD)
                {
                    char currOperator = char.Parse(match.Groups["operator"].Value);

                    if (currOperator == '*')
                    {
                        damage *= 2;
                    }
                    else if (currOperator == '/')
                    {
                        damage /= 2;    
                    }
                }

                nameAndDamage[input] = damage;
            }

            foreach (var nameHealth in nameAndHealth)
            {
                foreach (var nameDamage in nameAndDamage)
                {
                    if (nameHealth.Key == nameDamage.Key)
                    {
                        Console.WriteLine($"{nameHealth.Key} - {nameHealth.Value} health, {nameDamage.Value:f2} damage");
                        break;
                    }                    
                }
            }
        }
    }
}
