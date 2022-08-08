using System;

namespace GoldMine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numLocations = int.Parse(Console.ReadLine());
            double sumGoldForDay = 0;

            for (int i = 1; i <= numLocations; i++)
            {
                double averageGoldForDay = double.Parse(Console.ReadLine());
                int numDaysForLocation = int.Parse((Console.ReadLine()));

                for (int j = 1; j <= numDaysForLocation; j++)
                {
                    double goldForDay = double.Parse((Console.ReadLine()));
                    sumGoldForDay += goldForDay;                   
                }

                double averageSumGoldForDay = sumGoldForDay / numDaysForLocation;
                if (averageSumGoldForDay >= averageGoldForDay)
                {
                    Console.WriteLine($"Good job! Average gold per day: {averageSumGoldForDay:f2}.");
                }
                else
                {
                    double lessAverageSumGoldForDay = averageGoldForDay - averageSumGoldForDay;
                    Console.WriteLine($"You need {lessAverageSumGoldForDay:f2} gold.");
                }
                sumGoldForDay = 0;
            }
        }
    }
}
