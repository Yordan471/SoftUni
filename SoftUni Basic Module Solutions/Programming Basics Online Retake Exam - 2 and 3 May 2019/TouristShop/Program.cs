using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());

            double sum = 0;
            int counter = 0;
            int counterBoughtProducts = 0;
            bool stop = false;
            bool passBudget = false;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Stop")
                {
                    stop = true;
                    break;
                }

                string nameOfProduct = command;

                double priceOfProduct = double.Parse(Console.ReadLine());

                counter++;
                counterBoughtProducts++;

                if (counter == 3)
                {
                    priceOfProduct /= 2;
                    counter = 0;
                }
                   
                sum += priceOfProduct;

                if (sum > budget)
                {
                    passBudget = true;
                    break;
                }

                priceOfProduct = 0;
            }

            if (stop)
            {
                Console.WriteLine($"You bought {counterBoughtProducts} products for {sum:f2} leva.");
            }
            else if (passBudget)
            {
                double sumNeeded = sum - budget;
                Console.WriteLine($"You don't have enough money!");
                Console.WriteLine($"You need {sumNeeded:f2} leva!");
            }
        }
    }
}
