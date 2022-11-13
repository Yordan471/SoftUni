using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Fancy_Barcodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            string pattern = @"@#+(?<product>[A-Z][A-Za-z0-9]{4,}[A-Z])@#+";

            Regex regex= new Regex(pattern);
            List<string> productGroup = new List<string>();

            for (int i = 0; i < number; i++)
            {
                string barrcode = Console.ReadLine();

                Match match= regex.Match(barrcode);

                if (match.Success)
                {
                    char[] productToChars = match.Groups["product"]
                        .Value
                        .ToCharArray();

                    string group = string.Empty;
                    bool isDigit = false;

                    foreach (char c in productToChars)
                    {
                        if (char.IsDigit(c))
                        {
                            isDigit= true;
                            group += c;
                        }
                    }

                    if (!isDigit)
                    {
                        group = "00";
                    }

                    productGroup.Add($"Product group: {group}");
                }
                else
                {
                    productGroup.Add("Invalid barcode");
                }
            }
            
            Console.WriteLine(string.Join(Environment.NewLine, productGroup));
        }
    }
}
