using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisRanklist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberTournaments = int.Parse(Console.ReadLine());
            int startingPoints = int.Parse(Console.ReadLine());

            int points = 0;
            int counterWins = 0;

            for (int i = 1; i <= numberTournaments; i++)
            {
                string stage = Console.ReadLine();

                switch (stage)
                {
                    case "W":
                        points += 2000;
                        counterWins++;
                        break;
                    case "F":
                        points += 1200;
                        break;
                    case "SF":
                        points += 720;
                        break;
                }
            }

            int finalPoints = startingPoints + points;
            double avrgPoint = points * 1.0 / numberTournaments * 1.0;
            double prctngWin = (counterWins * 1.0 * 100) / numberTournaments * 1.0;

            Console.WriteLine($"Final points: {finalPoints}");
            Console.WriteLine($"Average points: {(Math.Floor(avrgPoint))}");
            Console.WriteLine($"{prctngWin:f2}%");
        }
    }
}
