using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double sumProduct = 0;
            double sumClient = 0;
            bool end = false;
            bool invalid = false;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Start")
                {
                    break;
                }

                double price = double.Parse(command);

                if (price == 0.1 || price == 0.2 || price == 0.5 ||
                    price == 1 || price == 2)
                {
                    sumClient += price;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {command}");
                }
            }

            while (true)
            {
                string product = Console.ReadLine();

                if (product == "End")
                {
                    end = true;
                    break;
                }

                switch (product)
                {
                    case "Nuts":
                        sumProduct = 2.0;
                        break;
                    case "Water":
                        sumProduct = 0.7;
                        break;
                    case "Crisps":
                        sumProduct = 1.5;
                        break;
                    case "Soda":
                        sumProduct += 0.8;
                        break;
                    case "Coke":
                        sumProduct = 1.0;
                        break;
                        default:
                        Console.WriteLine($"Invalid product");
                        invalid = true;
                        break;
                }

                sumClient -= sumProduct;

                if (sumClient >= 0 && invalid == false)
                {
                    product = product.ToLower();
                    Console.WriteLine($"Purchased {product}");
                }
                else if (sumClient < 0 && invalid == false)
                {
                    sumClient += sumProduct;
                    Console.WriteLine($"Sorry, not enough money");
                }

                sumProduct = 0;
            }

            double change = Math.Abs(sumClient);

            if (end)
            {
                Console.WriteLine($"Change: {change:f2}");
            }
        }
    }
}
