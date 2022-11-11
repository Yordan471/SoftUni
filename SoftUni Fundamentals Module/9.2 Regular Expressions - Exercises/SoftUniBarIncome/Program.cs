using System;
using System.Text.RegularExpressions;

namespace SoftUniBarIncome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^%(?<name>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<quantity>\d+)\|[^|$%.]*?(?<price>[-+]?[0-9]*\.?[0-9]+([eE][-+]?[0-9]+)?)\$";

            string command = string.Empty;
            double totalPrice = 0.0;

            while ((command = Console.ReadLine()) != "end of shift")
            {
                Match match = Regex.Match(command, pattern);

                if (match.Success)
                {
                    string name = match.Groups["name"].Value;
                    string product = match.Groups["product"].Value;
                    int quantity = int.Parse(match.Groups["quantity"].Value);
                    double price = double.Parse(match.Groups["price"].Value);

                    double fullPrice = quantity * 1.0 * price;
                    totalPrice += fullPrice;      

                    Console.WriteLine($"{name}: {product} - {fullPrice:f2}");
                }
            }

            Console.WriteLine($"Total income: {totalPrice:f2}");
        }
    }
}
