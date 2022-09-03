using System;

namespace Series
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int numSeries = int.Parse(Console.ReadLine());
            double sumOfAllSeries = 0;

            for (int i = 1; i <= numSeries; i++)
            {
                string seriesName = Console.ReadLine();
                double priceForSeries = double.Parse(Console.ReadLine());

                switch (seriesName)
                {
                    case "Thrones":
                        priceForSeries *= 0.50;
                        break;
                    case "Lucifer":
                        priceForSeries *= 0.60;
                        break;
                    case "Protector":
                        priceForSeries *= 0.70;
                        break;
                    case "TotalDrama":
                        priceForSeries *= 0.80;
                        break;
                    case "Area":
                        priceForSeries *= 0.90;
                        break;
                }

                sumOfAllSeries += priceForSeries;
            }

            if (sumOfAllSeries <= budget)
            {
                double moneyLeft = budget - sumOfAllSeries;
                Console.WriteLine($"You bought all the series and left with {moneyLeft:f2} lv.");
            }
            else if (sumOfAllSeries > budget)
            {
                double moneyNeeded = sumOfAllSeries - budget;
                Console.WriteLine($"You need {moneyNeeded:f2} lv. more to buy the series!");
            }
        }
    }
}
