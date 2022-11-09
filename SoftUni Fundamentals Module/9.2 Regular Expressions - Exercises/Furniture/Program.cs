using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            string pattern = @">>(?<furniture>[A-Za-z\s]+)<<(?<price>\d+(.\d+)?)!(?<quantity>[0-9]+)\b";

            List<string> furnitures = new List<string>();
            double sum = 0.0;
            
            while ((command = Console.ReadLine()) != "Purchase")
            {
                Match match = Regex.Match(command, pattern, RegexOptions.IgnoreCase);

                if (match.Success)
                {
                    sum += double.Parse(match.Groups["price"].Value) * int.Parse(match.Groups["quantity"].Value);
                    furnitures.Add(match.Groups["furniture"].Value);
                }
            }

            Console.WriteLine("Bought furniture:");

            if (furnitures.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, furnitures));
            }
                       
            Console.WriteLine($"Total money spend: {sum:f2}");
        }
    }
}
