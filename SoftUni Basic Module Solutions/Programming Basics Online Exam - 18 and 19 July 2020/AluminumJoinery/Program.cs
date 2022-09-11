using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluminumJoinery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfJoinery = int.Parse(Console.ReadLine());
            string typeOfJoinery = Console.ReadLine();
            string delivery = Console.ReadLine();

            double sum = 0;

            if (typeOfJoinery == "90X130")
            {
                if (numberOfJoinery > 30 && numberOfJoinery <= 60)
                {
                    sum += (110 * numberOfJoinery) * 0.95;
                }
                else if (numberOfJoinery > 60)
                {
                    sum += (110 * numberOfJoinery) * 0.92;
                }
                else if (numberOfJoinery >= 10 && numberOfJoinery <= 30)
                {
                    sum += 110 * numberOfJoinery;
                }
            }
            else if (typeOfJoinery == "100X150")
            {
                if (numberOfJoinery > 40 && numberOfJoinery <= 80)
                {
                    sum += (140 * numberOfJoinery) * 0.94;
                }
                else if (numberOfJoinery > 80)
                {
                    sum += (140 * numberOfJoinery) * 0.90;
                }
                else if (numberOfJoinery >= 10 && numberOfJoinery <= 40)
                {
                    sum += 140 * numberOfJoinery;
                }
            }
            else if (typeOfJoinery == "130X180")
            {
                if (numberOfJoinery > 20 && numberOfJoinery <= 50)
                {
                    sum += (190 * numberOfJoinery) * 0.93;
                }
                else if (numberOfJoinery > 50)
                {
                    sum += (190 * numberOfJoinery) * 0.88;
                }
                else if (numberOfJoinery >= 10 && numberOfJoinery <= 20)
                {
                    sum += 190 * numberOfJoinery;
                }
            }
            else if (typeOfJoinery == "200X300")
            {
                if (numberOfJoinery > 25 && numberOfJoinery <= 50)
                {
                    sum += (250 * numberOfJoinery) * 0.91;
                }
                else if (numberOfJoinery > 50)
                {
                    sum += (250 * numberOfJoinery) * 0.86;
                }
                else if (numberOfJoinery >= 10 && numberOfJoinery <= 25)
                {
                    sum += 250 * numberOfJoinery;
                }
            }

            if (delivery == "With delivery")
            {
                sum += 60;
            }

            if (numberOfJoinery > 99)
            {
                sum *= 0.96 * 1.0;
            }

            if (numberOfJoinery < 10)
            {
                Console.WriteLine($"Invalid order");
            }
            else
            {
                Console.WriteLine($"{sum:f2} BGN");
            }
        }
    }
}
