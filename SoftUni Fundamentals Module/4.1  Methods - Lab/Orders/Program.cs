using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());

            CalculatePriceForProduct(product, quantity);
        }

        static void CalculatePriceForProduct(string product, int quantity)
        {
            double priceSingleProduct = 0;

            switch (product)
            {
                case "coffee":
                    priceSingleProduct = 1.5;
                    Console.WriteLine($"{(priceSingleProduct * quantity):f2}");
                    break;
                case "water":
                    priceSingleProduct = 1.00;
                    Console.WriteLine($"{(priceSingleProduct * quantity):f2}");
                    break;
                case "coke":
                    priceSingleProduct = 1.40;
                    Console.WriteLine($"{(priceSingleProduct * quantity):f2}");
                    break;
                case "snacks":
                    priceSingleProduct = 2.00;
                    Console.WriteLine($"{(priceSingleProduct * quantity):f2}");
                    break;
            }
        }
    }
}
