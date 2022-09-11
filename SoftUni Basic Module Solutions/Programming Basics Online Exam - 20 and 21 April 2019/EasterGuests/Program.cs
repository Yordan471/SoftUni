using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasterGuests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1 easter cake for 3 people
            int numGuests = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            double easterCake = 4.00;
            double egg = 0.45;

            double sumForEasterCakes = Math.Ceiling(numGuests * 1.0 / 3) * easterCake;
            double priceForEggs = (numGuests * 2) * egg;

            double sum = sumForEasterCakes + priceForEggs;

            if (budget >= sum)
            {
                double sumLeft = budget - sum;
                Console.WriteLine($"Lyubo bought {Math.Ceiling(numGuests * 1.0 / 3)} Easter bread and {numGuests * 2} eggs.");
                Console.WriteLine($"He has {sumLeft:f2} lv. left.");
            }
            else if (budget < sum)
            {
                double sumNeededMore = sum - budget;
                Console.WriteLine($"Lyubo doesn't have enough money.");
                Console.WriteLine($"He needs {sumNeededMore:f2} lv. more.");
            }
        }
    }
}
