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
            int orders = int.Parse(Console.ReadLine());

            double sumPrice = 0;

            for (int i = 1; i <= orders; i++)
            {
                double pricePerCapsule = double.Parse(Console.ReadLine());
                int days = int.Parse(Console.ReadLine());
                int capsuleCount = int.Parse(Console.ReadLine());

                double priceForCoffe = pricePerCapsule * days * capsuleCount;
                sumPrice += priceForCoffe;

                Console.WriteLine($"The price for the coffee is: ${priceForCoffe:f2}");
            }

            Console.WriteLine($"Total: ${sumPrice:f2}");
        }
    }
}
