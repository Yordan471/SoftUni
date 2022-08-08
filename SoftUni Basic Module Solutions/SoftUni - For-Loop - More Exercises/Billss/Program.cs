using System;

namespace Billss
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int month = int.Parse(Console.ReadLine());

            double averageBillsForMonth = 0;
            int water = 20;
            int waterAllMonths = 0;
            int internet = 15;
            int internetAllMonths = 0;
            double others = 0;
            double electricityAllMonths = 0;

            for (int i = 1; i <= month; i++)
            {
                double electricity = double.Parse(Console.ReadLine());

                electricityAllMonths += electricity;
                waterAllMonths += 20;
                internetAllMonths += 15;
                others += (electricity + water + internet) + (electricity + water + internet) * 0.20;
            }

            Console.WriteLine($"Electricity: {electricityAllMonths:f2} lv");
            Console.WriteLine($"Water: {waterAllMonths:f2} lv");
            Console.WriteLine($"Internet: {internetAllMonths:f2} lv");
            Console.WriteLine($"Other: {others:f2} lv");

            averageBillsForMonth = (electricityAllMonths + waterAllMonths + internetAllMonths + others) / month;
            Console.WriteLine($"Average: {averageBillsForMonth:f2} lv");
        }
    }
}
