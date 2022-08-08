using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingBoat
{
    public class Program
    {
        static void Main(string[] args)
        {
            int priceSpring = 3000;
            int priceSummer = 4200; double priceAutumn = 4200;
            int priceWinter = 2600;
            double discount = 0.0;           

            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fisherman = int.Parse(Console.ReadLine());

            if (fisherman <= 6)
            {
                switch (season)
                {
                    case "Spring":
                        discount = priceSpring * 0.1; break;
                    case "Summer":
                        discount = priceSummer * 0.1; break;
                    case "Autumn":
                        discount = priceAutumn * 0.1; break;
                    case "Winter":
                        discount = priceWinter * 0.1; break;
                }
            }
            else if (fisherman >=7 && fisherman <=11)
            {
                switch (season)
                {
                    case "Spring":
                        discount = priceSpring * 0.15; break;
                    case "Summer":
                        discount = priceSummer * 0.15; break;
                    case "Autumn":
                        discount = priceAutumn * 0.15; break;
                    case "Winter":
                        discount = priceWinter * 0.15; break;
                }
            }
            else if (fisherman > 12)
            {
                switch (season)
                {
                    case "Spring":
                        discount = priceSpring * 0.25; break;
                    case "Summer":
                        discount = priceSummer * 0.25; break;
                    case "Autumn":
                        discount = priceAutumn * 0.25; break;
                    case "Winter":
                        discount = priceWinter * 0.25; break;
                }
            }
            double money = 0.0;

            switch (season)
            {
                case "Spring":
                    money = priceSpring - discount; break;
                case "Summer":
                    money = priceSummer - discount; break;
                case "Autumn":
                    money = priceAutumn - discount; break;
                case "Winter":
                    money = priceWinter - discount; break;
            }
            if (fisherman % 2 == 0 && season != "Autumn")
            {
                switch (season)
                {
                    case "Spring":
                        money -= money * 0.05; break;
                    case "Summer":
                        money -= money * 0.05; break;
                    case "Autumn":
                        money -= money * 0.05; break;
                    case "Winter":
                        money -= money * 0.05; break;
                }
            }
            if (budget >= money)
            {
                Console.WriteLine($"Yes! You have {budget - money:f2} leva left.");
            }
            else if (money > budget)
            {
                Console.WriteLine($"Not enough money! You need {money - budget:f2} leva.");
            }                        
        }
    }
}
