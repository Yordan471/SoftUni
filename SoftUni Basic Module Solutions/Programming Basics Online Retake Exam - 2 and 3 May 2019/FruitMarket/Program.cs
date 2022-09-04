using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitMarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double strawberries = double.Parse(Console.ReadLine());
            double quantityBananas = double.Parse(Console.ReadLine());
            double quantityOranges = double.Parse(Console.ReadLine());
            double quantityRaspberries = double.Parse(Console.ReadLine());
            double quantityStrawberries = double.Parse(Console.ReadLine());

            double raspberries = strawberries / 2;
            double priceRaspberries = raspberries * quantityRaspberries;

            double oranges = raspberries * 0.60;
            double priceOranges = oranges * quantityOranges;

            double bananas = raspberries * 0.20;
            double priceBananas = bananas * quantityBananas;

            double priceStrawberries = strawberries * quantityStrawberries;

            double sum = priceStrawberries + priceRaspberries + priceOranges + priceBananas;

            Console.WriteLine($"{sum:f2}");
            
        }
    }
}
