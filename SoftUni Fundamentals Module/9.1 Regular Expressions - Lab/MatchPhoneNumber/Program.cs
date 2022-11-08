using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace MatchPhoneNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\+359([ \-])2\1[0-9]{3}\1[0-9]{4}\b";

            string phoneNumbers = Console.ReadLine();

            MatchCollection phoneMatches = Regex.Matches(phoneNumbers, pattern);

            string[] matchedPhones = phoneMatches
                .Cast<Match>()
                .Select(x => x.Value.Trim())
                .ToArray();

            Console.WriteLine(string.Join(", ", matchedPhones));
        }
    }
}
