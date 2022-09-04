using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileOperator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string periodOfContract = Console.ReadLine();
            string typeOfContract = Console.ReadLine();
            string additionalMobileInternet = Console.ReadLine();   
            int numberOfMonthsToPay = int.Parse(Console.ReadLine());

            double sum = 0;

            if (periodOfContract == "one")
            {
                switch (typeOfContract)
                {
                    case "Small":
                        sum += 9.98;
                        break;
                    case "Middle":
                        sum += 18.99;
                        break;
                    case "Large":
                        sum += 25.98;
                        break;
                    case "ExtraLarge":
                        sum += 35.99;
                        break;
                }
            }
            else if (periodOfContract == "two")
            {
                switch (typeOfContract)
                {
                    case "Small":
                        sum += 8.58;
                        break;
                    case "Middle":
                        sum += 17.09;
                        break;
                    case "Large":
                        sum += 23.59;
                        break;
                    case "ExtraLarge":
                        sum += 31.79;
                        break;
                }
            }

            if (additionalMobileInternet == "yes")
            {
                if (sum <= 10)
                {
                    sum += 5.50;
                }
                else if (sum <= 30 && sum > 10)
                {
                    sum += 4.35;
                }
                else if (sum > 30)
                {
                    sum += 3.85;
                }
            }

            double sumNeeded = sum * numberOfMonthsToPay;

            if (periodOfContract == "two")
            {
                sumNeeded *= 0.9625;
            }

            Console.WriteLine($"{sumNeeded:f2} lv.");
        }
    }
}
