using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetParking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());

            double sum = 0;
            double saveSum = 0;

            double taxEvenDayOddHour = 2.50;
            double taxOddDayEvenHour = 1.25;
            double anyOther = 1;

            for (int i = 1; i <= days; i++)
            {
                for (int j = 1; j <= hours; j++)
                {
                    if (i % 2 == 0 && j % 2 != 0)
                    {
                        sum += taxEvenDayOddHour;
                    }
                    else if (i % 2 != 0 && j % 2 == 0)
                    {
                        sum += taxOddDayEvenHour;
                    }
                    else
                    {
                        sum += anyOther;
                    }
                }

                Console.WriteLine($"Day: {i} - {sum:f2} leva");
                saveSum += sum;
                sum = 0;
            }

            Console.WriteLine($"Total: {saveSum:f2} leva");
        }
    }
}
