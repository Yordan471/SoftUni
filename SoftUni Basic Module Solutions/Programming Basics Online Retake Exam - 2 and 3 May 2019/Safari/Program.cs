using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double litersFuelNeeded = double.Parse(Console.ReadLine());
            string dayOfWeek = Console.ReadLine();

            double fuelForLiter = 2.10;
            double priceForTourGuide = 100;

            double moneyForFuel = fuelForLiter * litersFuelNeeded;
            double sumNeeded = moneyForFuel + priceForTourGuide;

            if (dayOfWeek == "Saturday")
            {
                sumNeeded *= 0.90;
            }
            else if (dayOfWeek == "Sunday")
            {
                sumNeeded *= 0.80;
            }

            if (sumNeeded <= budget)
            {
                double moneyLeft = budget - sumNeeded;
                Console.WriteLine($"Safari time! Money left: {moneyLeft:f2} lv.");
            }
            else if (sumNeeded > budget)
            {
                double moreMoneyNeeded = sumNeeded - budget;
                Console.WriteLine($"Not enough money! Money needed: {moreMoneyNeeded:f2} lv.");
            }
        }
    }
}
