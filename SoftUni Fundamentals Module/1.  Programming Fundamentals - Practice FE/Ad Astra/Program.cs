using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace Ad_Astra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string foodInformation = Console.ReadLine();

            string pattern = @"([#|])(?<itemName>[A-Z][a-z]+( ([A-Z][a-z]+))?)\1(?<expirationDate>[0-9]{2}\/[0-9]{2}\/[0-9]{2})\1(?<calories>\d+)\1";
            int sumCalories = 0;
            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(foodInformation);

            foreach (Match match in matches)
            {
                if (match.Success)
                {
                    sumCalories += int.Parse(match.Groups["calories"].Value);
                }
            }

            int daysWithFood = sumCalories / 2000;

            Console.WriteLine($"You have food to last you for: {daysWithFood} days!");

            foreach (Match match in matches)
            {
                if (match.Success)
                {
                    string itemName = match.Groups["itemName"].Value;
                    string expirationDate = match.Groups["expirationDate"].Value;
                    string calories = match.Groups["calories"].Value;
                    Console.WriteLine($"Item: {itemName}, Best before: {expirationDate}, Nutrition: {calories}");
                }               
            }
        }
    }
}
