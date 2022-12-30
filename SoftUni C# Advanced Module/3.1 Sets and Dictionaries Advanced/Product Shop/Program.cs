using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;

            Dictionary<string, Dictionary<string, decimal>> shopAndProductPrice = new Dictionary<string, Dictionary<string, decimal>>();

            while ((command = Console.ReadLine()) != "Revision")
            {
                string[] shopInfo = command
                    .Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string shop = shopInfo[0];
                string product = shopInfo[1];
                decimal price = decimal.Parse(shopInfo[2]);

                if (!(shopAndProductPrice.ContainsKey(shop)))
                {
                    Dictionary<string, decimal> productAndPrice = new Dictionary<string, decimal>();

                    productAndPrice[product] = price;               
                    shopAndProductPrice[shop] = productAndPrice;
                }
                else
                {
                    if (!(shopAndProductPrice[shop].ContainsKey(product)))
                    {
                        shopAndProductPrice[shop].Add(product, price);
                    }
                    else
                    {
                        shopAndProductPrice[shop][product] = price;
                    }
                }
            }

            foreach (var shop in shopAndProductPrice.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value:f1}");
                }
            }
        }
    }
}
