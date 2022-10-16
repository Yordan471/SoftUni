using System;
using System.Diagnostics.Tracing;

namespace BlackFlag
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int daysOfPlunder = int.Parse(Console.ReadLine());
            int dailyPlunder = int.Parse(Console.ReadLine());
            decimal expectedPlunder = decimal.Parse(Console.ReadLine());

            decimal sumPlunder = 0;
            int counterDays = 0;

            for (int i = 1; i <= daysOfPlunder; i++)
            {
                counterDays++;

                sumPlunder += dailyPlunder;

                if (counterDays % 3 == 0)
                {
                    sumPlunder += 0.50M * dailyPlunder * 1.0M;
                }

                if (counterDays % 5 == 0)
                {
                    sumPlunder -= 0.30M * sumPlunder;
                }
            }

            if (sumPlunder >= expectedPlunder)
            {
                Console.WriteLine($"Ahoy! {sumPlunder:f2} plunder gained.");
            }
            else
            {
                decimal diff = expectedPlunder - sumPlunder;
                decimal prcntgGained = (diff * 100M) * 1.0M / diff * 1.0M;
                Console.WriteLine($"Collected only {prcntgGained:f2}% of the plunder.");
            }
        }
    }
}
