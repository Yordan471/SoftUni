using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BasketballTournament
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nameOfTournament = Console.ReadLine();

            int counterMatch = 0;
            int counterWins = 0;
            int counterLoss = 0;
            int allMatches = 0;

            while (true)
            {
                int numberTournaments = int.Parse(Console.ReadLine());

                for (int i = 1; i <= numberTournaments; i++)
                {
                    int desiTeamPoints = int.Parse(Console.ReadLine());
                    int secondTeamPoints = int.Parse(Console.ReadLine());

                    counterMatch++;

                    if (desiTeamPoints > secondTeamPoints)
                    {
                        counterWins++;
                        int diff = desiTeamPoints - secondTeamPoints;
                        Console.WriteLine($"Game {counterMatch} of tournament {nameOfTournament}: win with {diff} points.");
                    }
                    else if (secondTeamPoints > desiTeamPoints)
                    {
                        counterLoss++;
                        int diff = secondTeamPoints - desiTeamPoints;
                        Console.WriteLine($"Game {counterMatch} of tournament {nameOfTournament}: lost with {diff} points.");
                    }
                }

                allMatches += counterMatch;
                counterMatch = 0;

                string tournamentName = Console.ReadLine();

                if (tournamentName == "End of tournaments")
                {
                    break;
                }
            }

            double prcntgWins = (counterWins * 1.0 * 100) / allMatches * 1.0;
            Console.WriteLine($"{prcntgWins:f2}% matches win");

            double prcntgLoss = (counterLoss * 1.0 * 100) / allMatches * 1.0;
            Console.WriteLine($"{prcntgLoss:f2}% matches lost");
        }
    }
}
