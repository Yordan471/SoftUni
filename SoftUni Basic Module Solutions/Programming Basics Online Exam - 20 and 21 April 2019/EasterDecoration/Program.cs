using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasterDecoration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberClients = int.Parse(Console.ReadLine());
            string purchase = "";

            double basket = 1.50;
            double wreath = 3.80;
            double chocolateBunny = 7;
            double sum = 0;
            int counterPurchase = 0;
            double collectedMoney = 0;

            for (int i = 1; i <= numberClients; i++)
            {
                while (true)
                {
                    purchase = Console.ReadLine();

                    if (purchase == "Finish")
                    {
                        break;
                    }

                    counterPurchase++;

                    switch (purchase)
                    {
                        case "basket":
                            sum += basket;
                            break;
                        case "wreath":
                            sum += wreath;
                            break;
                        case "chocolate bunny":
                            sum += chocolateBunny;
                            break;
                    }
                }

                if (counterPurchase % 2 == 0)
                {
                    sum *= 0.80;
                }

                Console.WriteLine($"You purchased {counterPurchase} items for {sum:f2} leva.");

                counterPurchase = 0;
                collectedMoney += sum;
                sum = 0;
                purchase = "";
            }

            double avrgSum = collectedMoney / numberClients;
            Console.WriteLine($"Average bill per client is: {avrgSum:f2} leva.");
        }
    }
}
