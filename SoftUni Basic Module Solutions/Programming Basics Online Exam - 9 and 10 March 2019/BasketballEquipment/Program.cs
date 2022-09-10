using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballEquipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int annualTaxForBasketball = int.Parse(Console.ReadLine());

            double basketballShoes = annualTaxForBasketball * 1.0 * 0.6;
            double basketballClothes = basketballShoes * 0.8;
            double ball = basketballClothes * 0.25;
            double basketballAccessories = ball * 0.20;

            double sum = basketballAccessories + basketballClothes + basketballShoes + ball + annualTaxForBasketball;

            Console.WriteLine($"{sum:f2}");
        }
    }
}
