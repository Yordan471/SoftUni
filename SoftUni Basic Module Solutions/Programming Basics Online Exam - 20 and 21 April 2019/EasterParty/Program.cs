using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasterParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfGuests = int.Parse(Console.ReadLine());
            double pricePerPerson = double.Parse(Console.ReadLine());
            double budget = double.Parse((Console.ReadLine()));

            double priceForAllGuests = numberOfGuests * 1.0 * pricePerPerson;

            if (numberOfGuests >= 10 && numberOfGuests <= 15)
            {
                priceForAllGuests *= 0.85;
            }
            else if (numberOfGuests > 15 && numberOfGuests <= 20)
            {
                priceForAllGuests *= 0.80;
            }
            else if (numberOfGuests > 20)
            {
                priceForAllGuests *= 0.75;
            }

            double priceForCake = budget * 0.10;

            double sumNeeded = priceForAllGuests + priceForCake;

            if (budget >= sumNeeded)
            {
                double sumLeft = budget - sumNeeded;
                Console.WriteLine($"It is party time! {sumLeft:f2} leva left.");
            }
            if (budget < sumNeeded)
            {
                double sumNeededMore = sumNeeded - budget;
                Console.WriteLine($"No party! {sumNeededMore:f2} leva needed.");
            }       
        }
    }
}
