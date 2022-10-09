using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuineaPig
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal quantityFood = decimal.Parse(Console.ReadLine());
            decimal quantityHay = decimal.Parse(Console.ReadLine());
            decimal quantityCover = decimal.Parse(Console.ReadLine());
            decimal pigWeight = decimal.Parse(Console.ReadLine());

            int counterDays = 0;
            bool outOfProvisions = false;

            while (counterDays != 30)
            {
                counterDays++;

                quantityFood -= 0.300M;

                if (counterDays % 2 == 0)
                {
                    quantityHay -= 0.05M * quantityFood;
                }

                if (counterDays % 3 == 0)
                {
                    quantityCover -= 0.33333333333M * pigWeight;
                }

                if (quantityFood <= 0 || quantityHay <= 0 ||
                    quantityCover <= 0)
                {
                    outOfProvisions = true;
                    break;
                }
            }

            if (outOfProvisions)
            {
                Console.WriteLine("Merry must go to the pet store!");
            }
            else
            {
                Console.WriteLine($"Everything is fine! Puppy is happy! Food: {quantityFood:f2}, Hay: {quantityHay:f2}, Cover: {quantityCover:f2}.");
            }
        }
    }
}
