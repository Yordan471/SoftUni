using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text.RegularExpressions;

namespace Nether_Realms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string patternDamage = @"[-+]?[0-9]+(.[0-9]+)?([*\/]+)?";
            string patternNames = @"(?<name>[A-Za-z\d\-.*\/]+)([0, ]*)?\k<name>?";

            string demonNames = Console.ReadLine();

            Dictionary <string, int> nameAndHealth = new Dictionary<string, int>();
            Dictionary <string, int> nameAndDamage = new Dictionary<string, int>();

            Regex regexName = new Regex(patternNames);

            MatchCollection mathes = regexName.Matches(demonNames);

            foreach (Match match in mathes)
            {
                nameAndHealth[match.Groups["name"].Value] = 0;
                nameAndDamage[match.Groups["name"].Value] = 0;
            }

            int health = 0;
            
            foreach (var name in nameAndHealth)
            {
                char[] toChars = name.Key.ToCharArray();
                health = 0;

                for (int i = 0; i < toChars.Length; i++) 
                { 
                    if (char.IsLetter(toChars[i]))
                    {
                        int charater = toChars[i];
                        health += charater;
                    }                  
                }

                nameAndHealth[name.Key] = health;
            }
            
            Regex regexDamage = new Regex(patternDamage);


            foreach (var name in nameAndDamage)
            {
                MatchCollection matchesDigits = regexDamage.Matches(name.Key);

                foreach (var match in matchesDigits)
                {

                }



            }

            
        }
    }
}
