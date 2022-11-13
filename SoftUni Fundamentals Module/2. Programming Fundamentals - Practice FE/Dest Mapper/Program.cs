using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Dest_Mapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([=\/]{1})(?<location>[A-Z][A-Za-z]{2,})\1";

            string inputInfo = Console.ReadLine();
            List<string> matchList = new List<string>();

            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(inputInfo);

            int travelPoints = 0;

            foreach (Match match in matches)
            {
                if (match.Success)
                {
                    matchList.Add(match.Groups["location"].Value);
                    travelPoints += match.Groups["location"].Value.Length;
                }           
            }
            
            if (matchList.Count > 0)
            {
                Console.Write("Destinations: ");
                Console.WriteLine(string.Join(", ", matchList));
            }
            else
            {
                Console.WriteLine("Destinations:");
            }

            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
