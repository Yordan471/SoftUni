using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PadawanEqupment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int numberOfStudents = int.Parse(Console.ReadLine());
            double priceForLightsaber = double.Parse(Console.ReadLine());
            double priceForRobe = double.Parse(Console.ReadLine());
            double priceForBelt = double.Parse(Console.ReadLine());

            int counterBelt = 0;
            int counterBeltSave = 0;
            double counterLightsaber = 0;
            int counterRobe = 0;

            counterLightsaber = Math.Ceiling(numberOfStudents * 0.1);

            for (int i = 1; i <= numberOfStudents; i++)
            {
                counterBeltSave++;
                counterBelt++;
                counterLightsaber++;
                counterRobe++;

                if (counterBeltSave % 6 == 0)
                {
                    counterBelt--;
                }
            }

            double sumPriceLightsabers = counterLightsaber * priceForLightsaber;
            double sumPriceBelts = counterBelt * priceForBelt;
            double sumPriceRobes = counterRobe * priceForRobe;

            double sumAllEquipment = sumPriceBelts + sumPriceLightsabers + sumPriceRobes;

            if (budget >= sumAllEquipment)
            {
                Console.WriteLine($"The money is enough - it would cost {sumAllEquipment:f2}lv.");
            }
            else if (budget < sumAllEquipment)
            {
                double moreMoneyNeeded = sumAllEquipment - budget;
                Console.WriteLine($"John will need {moreMoneyNeeded:f2}lv more.");
            }
        }
    }
}
