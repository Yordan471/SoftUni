using System;

namespace ReportSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int moneyFromSells = int.Parse(Console.ReadLine());

            string command = "";
            decimal moneySum = 0;
            int counter = 0;
            decimal moneyCash = 0;
            int counterCash = 0;
            decimal moneyCard = 0;
            int counterCard = 0;
            bool flag = false;
            bool failed = false;

            while (command != "End")
            {
                command = Console.ReadLine();
                if (command == "End")
                {
                    failed = true;
                    break;
                }

                decimal itemsPrice = decimal.Parse(command);
                counter++;
                if (counter % 2 != 0)
                {
                    if (itemsPrice > 100)
                    {
                        Console.WriteLine($"Error in transaction!");
                    }

                    else
                    {
                        counterCash++;
                        moneySum += itemsPrice;
                        moneyCash += itemsPrice;

                        Console.WriteLine($"Product sold!");
                        if (moneySum >= moneyFromSells)
                        {
                            flag = true;
                            break;
                        }
                    }
                }

                else if (counter % 2 == 0)
                {
                    if (itemsPrice < 10)
                    {
                        Console.WriteLine($"Error in transaction!");            
                    }

                    else
                    {
                        counterCard++;
                        moneySum += itemsPrice;
                        moneyCard += itemsPrice;

                        Console.WriteLine($"Product sold!");
                        if (moneySum >= moneyFromSells)
                        {
                            flag = true;
                            break;
                        }
                    }
                }
            }

            if (flag)
            {
                decimal averageCash = moneyCash / counterCash;
                decimal averageCard = moneyCard / counterCard;

                Console.WriteLine($"Average CS: {averageCash:f2}");
                Console.WriteLine($"Average CC: {averageCard:f2}");
            }

            if (failed)
            {
                Console.WriteLine($"Failed to collect required money for charity.");
            }    
        }
    }
}
