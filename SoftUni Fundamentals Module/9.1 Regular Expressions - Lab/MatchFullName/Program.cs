using System;
using System.Text.RegularExpressions;

namespace MatchFullName
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string regex = @"(?<fullName>(?<firstName>\b[A-Z][a-z]+) (?<lastName>[A-Z][a-z]+\b))";

            string names = Console.ReadLine();

            MatchCollection matchNames = Regex.Matches(names, regex);

            foreach (Match match in matchNames)
            {

                Console.Write(match.Value + " ");
            }

            Console.WriteLine();
        }
    }
}
