using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasterShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startingNumberEggs = int.Parse(Console.ReadLine());
            int saveStartingNumberEggs = startingNumberEggs;

            int sumEggs = 0;
            bool close = false;
            bool moreThen = false;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Close")
                {
                    close = true;
                    break;
                }

                int numEggs = int.Parse(Console.ReadLine());

                if (command == "Buy")
                {
                    sumEggs += numEggs;

                    if (sumEggs > saveStartingNumberEggs)
                    {
                        moreThen = true;
                        sumEggs -=numEggs;
                        break;
                    }
                }
                else if (command == "Fill")
                {
                    saveStartingNumberEggs += numEggs;
                }      
            }

            if (close)
            {
                Console.WriteLine($"Store is closed!");
                Console.WriteLine($"{sumEggs} eggs sold.");
            }
            else if (moreThen)
            {
                int eggsLeft = saveStartingNumberEggs - sumEggs;
                Console.WriteLine($"Not enough eggs in store!");
                Console.WriteLine($"You can buy only {eggsLeft}.");
            }
        }
    }
}
