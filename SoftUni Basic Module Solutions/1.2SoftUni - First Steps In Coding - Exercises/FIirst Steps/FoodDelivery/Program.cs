using System;

namespace FoodDelivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double chickenMenu = 10.35;
            double fishMenu = 12.40;
            double vegeMenu = 8.15;
            double dostavka = 2.5;

            int brChickenMenu = int.Parse(Console.ReadLine());
            int brFishMenu = int.Parse(Console.ReadLine());
            int brVegeMenu = int.Parse(Console.ReadLine());

            double fullPrice = brChickenMenu * chickenMenu + brFishMenu * fishMenu + brVegeMenu * vegeMenu;
            double desert = 0.20 * fullPrice;
            double fullPriceHome = fullPrice + desert + dostavka;

            Console.WriteLine(fullPriceHome);
        }
    }
}
