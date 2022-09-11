using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddBags
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double taxBagageOver20Kg = double.Parse(Console.ReadLine());
            double kgForBagage = double.Parse(Console.ReadLine());
            int daysTillDeparture = int.Parse(Console.ReadLine());
            int numberOfBagages = int.Parse(Console.ReadLine());

            double taxForBagage = 0;

            if (kgForBagage < 10)
            {
                taxForBagage += taxBagageOver20Kg * 0.20;
            }
            else if (kgForBagage >= 10 && kgForBagage <= 20)
            {
                taxForBagage += taxBagageOver20Kg * 0.50;
            }
            else if (kgForBagage > 20)
            {
                taxForBagage = taxBagageOver20Kg;
            }

            if (daysTillDeparture > 30)
            {
                taxForBagage *= 1.10;
            }
            else if (daysTillDeparture >= 7 && daysTillDeparture <= 30)
            {
                taxForBagage *= 1.15;
            }
            else if (daysTillDeparture < 7)
            {
                taxForBagage *= 1.40;
            }

            double priceForAllBaggages = taxForBagage * numberOfBagages * 1.0;

            Console.WriteLine($"The total price of bags is: {priceForAllBaggages:f2} lv.");
        }
    }
}
