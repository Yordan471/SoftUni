using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasterEggsBattle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int eggsFirstPlayer = int.Parse(Console.ReadLine());
            int eggsSecondPlayer = int.Parse(Console.ReadLine());

            int firstPlayerPoints = eggsFirstPlayer;
            int secondPlayerPoints = eggsSecondPlayer;
            bool firstPlayerWins = false;
            bool secondPlayerWins = false;
            bool end = false;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    end = true;
                    break;
                }

                if (command == "one")
                {
                    secondPlayerPoints--;

                    if (secondPlayerPoints == 0)
                    {
                        firstPlayerWins = true;
                        break;
                    }
                }
                else if (command == "two")
                {
                    firstPlayerPoints--;

                    if (firstPlayerPoints == 0)
                    {
                        secondPlayerWins = true;
                        break;
                    }
                }
            }

            if (firstPlayerWins)
            {
                Console.WriteLine($"Player two is out of eggs. Player one has {firstPlayerPoints} eggs left.");
            }
            else if (secondPlayerWins)
            {
                Console.WriteLine($"Player one is out of eggs. Player two has {secondPlayerPoints} eggs left.");
            }
            else if (end)
            {
                Console.WriteLine($"Player one has {firstPlayerPoints} eggs left.");
                Console.WriteLine($"Player two has {secondPlayerPoints} eggs left.");
            }
        }
    }
}
