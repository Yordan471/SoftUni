using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());

            string command = "";

            double price = 0;
            double allSpendMoney = 0;
            bool gameTime = false;
            bool outOfMoney = false;
            bool notFound = false;

            while(true)
            {
                command = Console.ReadLine();

                if (command == "Game Time")
                {
                    gameTime = true;
                    break;
                }

                string gameName = command;

                switch (gameName)
                {
                    case "OutFall 4":
                        price += 39.99;
                        break;
                    case "CS: OG":
                        price += 15.99;
                        break;
                    case "Zplinter Zell":
                        price += 19.99;
                        break;
                    case "Honored 2":
                        price += 59.99;
                        break;
                    case "RoverWatch":
                        price += 29.99;
                        break;
                    case "RoverWatch Origins Edition":
                        price += 39.99;
                        break;
                    default:
                        Console.WriteLine("Not Found");
                        notFound = true;
                        break;
                }

                allSpendMoney += price;
                budget -= price;

                if (budget == 0)
                {
                    outOfMoney = true;
                    break;
                }
                else if (budget < 0)
                {
                    Console.WriteLine("Too Expensive");
                    allSpendMoney -= price;
                    budget += price;
                }
                else
                {
                    if (notFound == false)
                    {
                        Console.WriteLine($"Bought {gameName}");
                    }
                    else if (notFound == true)
                    {
                        notFound = false;
                    }
                }

                price = 0;
            }

            if (gameTime)
            {             
                Console.WriteLine($"Total spent: ${allSpendMoney:f2}. Remaining: ${budget:f2}");
            }
            else if (outOfMoney)
            {
                Console.WriteLine($"Out of money!");
            }
        }
    }
}
