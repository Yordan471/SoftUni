using System;
using System.Runtime.ExceptionServices;

namespace HappyCatParking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numDays = int.Parse(Console.ReadLine());
            int numHoursForEveryDay = int.Parse(Console.ReadLine());

            double evenDayOddH = 2.50;
            double oddDayEvenH = 1.25;
            double everyOtherCase = 1;
            double sumOfTheDay = 0;
            double sumForAllDays = 0;
            int dayCounter = 0;

            for (int i = 1; i <= numDays; i++)
            {
                dayCounter++;               
                sumOfTheDay = 0;

                for (int j = 1; j <= numHoursForEveryDay; j++)
                {
                    if (i % 2 == 0 && j % 2 != 0)
                    {
                        sumOfTheDay += evenDayOddH;
                    }
                    else if (i % 2 != 0 && j % 2 == 0)
                    {
                        sumOfTheDay += oddDayEvenH;
                    }
                    else
                    {
                        sumOfTheDay += everyOtherCase;
                    }
                }

                sumForAllDays += sumOfTheDay;
                Console.WriteLine($"Day: {dayCounter} - {sumOfTheDay:f2} leva");
            }

            Console.WriteLine($"Total: {sumForAllDays:f2} leva");
        }
    }
}
