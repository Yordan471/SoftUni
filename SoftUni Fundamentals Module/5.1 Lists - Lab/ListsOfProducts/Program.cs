using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListsOfProducts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfProducts = int.Parse(Console.ReadLine());

            List<string> products = new List<string>();

            for (int i = 1; i <= numberOfProducts; i++)
            {
                string productName = Console.ReadLine();

                products.Add(productName);
            }

            products.Sort();

            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{products[i]}");
            }
        }
    }
}
