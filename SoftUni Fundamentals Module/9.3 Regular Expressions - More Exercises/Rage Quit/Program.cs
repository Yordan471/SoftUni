using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Rage_Quit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputInfo = Console.ReadLine();

            string pattern = @"(?<string>[ -\/:-~]+)(?<digit>[0-9]{0,2})";

            Dictionary <string, int> stringAndDigit = new Dictionary<string, int>();

            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(inputInfo);

            StringBuilder outputInfo = new StringBuilder();

            foreach (Match match in matches)
            {
                string letters = match.Groups["string"].Value;
                int number = int.Parse(match.Groups["digit"].Value);

                for (int i = 0; i < number; i++)
                {
                    outputInfo.Append(letters);
                }
            }

            int countSymbols = 0;

            string lettersToString = outputInfo.ToString().ToUpper();
            countSymbols = lettersToString.Distinct().Count();

            Console.WriteLine($"Unique symbols used: {countSymbols}");
            Console.WriteLine(lettersToString);
        }
    }
}
