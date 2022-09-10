using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballResult
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string firstMatch = Console.ReadLine();
            string secondMatch = Console.ReadLine();
            string thirdMatch = Console.ReadLine();

            int counterWins = 0;
            int counterLoss = 0;
            int counterDraws = 0;

            char firstNumber = firstMatch[0];
            char secondNumber = firstMatch[2];

            char firstNumber2 = secondMatch[0];
            char secondNumber2 = secondMatch[2];

            char firstNumber3 = thirdMatch[0];
            char secondNumber3 = thirdMatch[2];

            if (firstNumber > secondNumber)
            {
                counterWins++;
            }
            else if (firstNumber < secondNumber)
            {
                counterLoss++;
            }
            else
            {
                counterDraws++;
            }

            if (firstNumber2 > secondNumber2)
            {
                counterWins++;
            }
            else if (firstNumber2 < secondNumber2)
            {
                counterLoss++;
            }
            else
            {
                counterDraws++;
            }

            if (firstNumber3 > secondNumber3)
            {
                counterWins++;
            }
            else if (firstNumber3 < secondNumber3)
            {
                counterLoss++;
            }
            else
            {
                counterDraws++;
            }

            Console.WriteLine($"Team won {counterWins} games.");
            Console.WriteLine($"Team lost {counterLoss} games.");
            Console.WriteLine($"Drawn games: {counterDraws}");
        }
    }
}
