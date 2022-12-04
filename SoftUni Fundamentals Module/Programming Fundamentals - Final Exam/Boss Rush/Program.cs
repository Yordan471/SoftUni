using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Boss_Rush
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputLines = int.Parse(Console.ReadLine());

            string pattern = @"([|])(?<name>[A-Z]{4,})([|]):{1}[#](?<title>[A-Z][a-z]+ [A-Za-z]+)([#])";

            Regex regex = new Regex(pattern);

            for (int i = 0; i < numberOfInputLines; i++)
            {
                Match match = regex.Match(Console.ReadLine());

                if (match.Success)
                {
                    string name = match.Groups["name"].Value;
                    string title = match.Groups["title"].Value;
                    

                    Console.WriteLine($"{name}, The {title}");
                    Console.WriteLine($">> Strength: {name.Length}");
                    Console.WriteLine($">> Armor: {title.Length}");
                }
                else
                {
                    Console.WriteLine("Access denied!");
                }
            }
        }
    }
}
