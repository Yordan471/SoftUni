using System;
using System.Text.RegularExpressions;

namespace MatchDates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\b(?<day>[0-9]{2})(?<separator>[-.\/])(?<month>[A-Z][a-z]{2})\k<separator>(?<year>[0-9]{4})\b";

            string dates = Console.ReadLine();

            MatchCollection matchDates = Regex.Matches(dates, pattern);

            foreach (Match match in matchDates)
            {
                string day = match.Groups["day"].Value;
                string month = match.Groups["month"].Value;
                string year = match.Groups["year"].Value;

                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }

            
        }
    }
}
