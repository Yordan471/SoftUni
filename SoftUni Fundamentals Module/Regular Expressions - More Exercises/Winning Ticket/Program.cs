using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Winning_Ticket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(?<ticket>[!-+\--~]+)([, ]+)?";

            string tickets = Console.ReadLine();

            MatchCollection matches = Regex.Matches(tickets, pattern);
            List<string> result = new List<string>();

            foreach (Match match in matches)
            {
                if (match.Success)
                {
                    char[] chars = match.Groups["ticket"].Value.ToCharArray();

                    for (int i = 0; i < chars.Length; i++)
                    {
                        if (c)
                    }
                }
            }
        }
    }
}
