using System;

namespace ExcursionCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numPeople = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            double sum = 0.00;

            if (numPeople <= 5)
            {
                switch (season)
                {
                    case "spring":
                        sum += 50.00; break;
                    case "autumn":
                        sum += 60.00; break;
                    case "summer":
                        sum += 48.50; break;
                    case "winter":
                        sum += 86.00; break;
                }
            }
            else if (numPeople > 5)
            {
                switch (season)
                {
                    case "spring":
                        sum += 48.00; break;
                    case "autumn":
                        sum += 49.50; break;
                    case "summer":
                        sum += 45.00; break;
                    case "winter":
                        sum += 85.00; break;
                }
            }
            double allSum = sum * numPeople;

            if (season == "summer")
            {
                double allSumDisc = allSum * 0.85;
                Console.WriteLine($"{allSumDisc:f2} leva.");
            }
            else if (season == "winter")
            {
                double allSumInc = allSum + (allSum * 0.08);
                Console.WriteLine($"{allSumInc:f2} leva.");
            }
            else
            {
                Console.WriteLine($"{allSum:f2} leva.");
            }
        }
    }
}
