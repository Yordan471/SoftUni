using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;

namespace Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] productInformation = Console.ReadLine()
                .Split()
                .ToArray();

            Dictionary<string, List<double>> productAndQuantity = new Dictionary<string, List<double>>();
            List<double> prices = new List<double>();
            string saveProduct = string.Empty;

            while (productInformation[0] != "buy")
            {
                double price = double.Parse(productInformation[1]);
                double quantity = double.Parse(productInformation[2]);  

                if (!productAndQuantity.ContainsKey(productInformation[0]))
                {                  
                    productAndQuantity.Add(productInformation[0], new List<double>() { price, quantity });
                }
                else
                {
                    productAndQuantity[productInformation[0]][0] = double.Parse(productInformation[1]);
                    productAndQuantity[productInformation[0]][1] += double.Parse(productInformation[2]);
                }
                
                productInformation = Console.ReadLine()
                .Split()
                .ToArray();
            }

            foreach (KeyValuePair<string, List<double>> product in productAndQuantity)
            {
                Console.WriteLine($"{product.Key} -> {(product.Value[0] * product.Value[1]):f2}");
            }
        }
    }
}
