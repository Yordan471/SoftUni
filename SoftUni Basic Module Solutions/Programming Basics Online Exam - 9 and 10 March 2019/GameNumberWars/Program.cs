using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameNumberWars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nameFirstPlayer = Console.ReadLine();
            string nameSecondPlayer = Console.ReadLine();

            string winnerName = "";
            double firstPlayerScores = 0;
            double secondPlayerScores = 0;
            bool endOfGame = false;
            bool numberWars = false;
            double winnerScore = 0;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End of game")
                {
                    endOfGame = true;
                    break;
                }

                int firstPlayerCard = int.Parse(command);
                int secondPlayerCard = int.Parse(Console.ReadLine());

                if (firstPlayerCard == secondPlayerCard)
                {
                    firstPlayerCard = int.Parse(Console.ReadLine());
                    secondPlayerCard = int.Parse(Console.ReadLine());
                    numberWars = true;

                    if (firstPlayerCard > secondPlayerCard)
                    {
                        winnerName = nameFirstPlayer;
                   //     firstPlayerScores += firstPlayerCard - secondPlayerCard;
                        winnerScore = firstPlayerScores;
                    }
                    else
                    {
                        winnerName = nameSecondPlayer;
                    //    secondPlayerCard += secondPlayerCard - firstPlayerCard;
                        winnerScore = secondPlayerScores;
                    }

                    break;
                }
                
                if (firstPlayerCard > secondPlayerCard)
                {
                    firstPlayerScores += firstPlayerCard - secondPlayerCard;
                }
                else if (firstPlayerCard < secondPlayerCard)
                {
                    secondPlayerScores += secondPlayerCard - firstPlayerCard;
                }
            }

            if (numberWars)
            {
                Console.WriteLine($"Number wars!");
                Console.WriteLine($"{winnerName} is winner with {winnerScore} points");
            }
            else if (endOfGame)
            {
                Console.WriteLine($"{nameFirstPlayer} has {firstPlayerScores} points");
                Console.WriteLine($"{nameSecondPlayer} has {secondPlayerScores} points");
            }
        }
    }
}
