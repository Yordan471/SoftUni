using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] waterInput = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            double[] flourInput = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            Queue<double> water = new Queue<double>(waterInput);
            Stack<double> flour = new Stack<double>(flourInput);

            Dictionary<string, string> productAndMix = new Dictionary<string, string>()
            {
                { "50:50", "Croissant" },
                { "40:60", "Muffin" },
                { "30:70", "Baguette" },
                { "20:80", "Bagel" }
            };
            Dictionary<string, int> productAndAmount = new Dictionary<string, int>();

            while (water.Count != 0 && flour.Count != 0)
            {
                double mixValue = water.Peek() + flour.Peek();
                double prcntgWater = water.Peek() * 100 / mixValue;
                double prcntgFlour = flour.Peek() * 100 / mixValue;

                if (productAndMix.ContainsKey(prcntgWater + ":" + prcntgFlour))
                {
                    if (!productAndAmount.ContainsKey(productAndMix[prcntgWater + ":" + prcntgFlour]))
                    {
                        productAndAmount.Add(productAndMix[prcntgWater + ":" + prcntgFlour], 0);
                    }

                    productAndAmount[productAndMix[prcntgWater + ":" + prcntgFlour]]++;
                    flour.Pop();
                }
                else
                {
                    double flourLeft = flour.Pop() - water.Peek();
                    flour.Push(flourLeft);

                    if (!productAndAmount.ContainsKey("Croissant"))
                    {
                        productAndAmount.Add("Croissant", 0);
                    }

                    productAndAmount["Croissant"]++;
                }

                water.Dequeue();
            }

            foreach (var product in productAndAmount.OrderByDescending(v => v.Value).ThenBy(k => k.Key))
            {
                Console.WriteLine($"{product.Key}: {product.Value}");
            }

            if (water.Count > 0)
            {
                Console.WriteLine($"Water left: {string.Join(", ", water)}");
            }
            else
            {
                Console.WriteLine("Water left: None");
            }

            if (flour.Count > 0)
            {
                Console.WriteLine($"Flour left: {string.Join(", ", flour)}");
            }
            else
            {
                Console.WriteLine("Flour left: None");
            }
        }
    }
}
