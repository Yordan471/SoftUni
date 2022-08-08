using System;

namespace WorldTennisCup
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int tournamentsNum = int.Parse(Console.ReadLine());
            int initialPoints = int.Parse(Console.ReadLine());

            int thisYearsPoints = 0;
            int winsCounter = 0;

            for (int i = 1; i <= tournamentsNum; i++)
            {
                string position = Console.ReadLine();

                switch(position)                
                {
                    case "W":
                        thisYearsPoints += 2000; 
                        winsCounter++; //прибавяме +1 за всяка победа, за да можем да разделим накрая наполовина и да разберем процента победи от всички турнири.
                        break;
                    case "F":
                        thisYearsPoints += 1200;  
                        break;
                    case "SF":
                        thisYearsPoints += 720;
                        break;                       
                }
            }
            int finalPoints = initialPoints + thisYearsPoints;
            Console.WriteLine($"Final points: {finalPoints}");

            double avaragePointsForTournament = Math.Floor(thisYearsPoints / (tournamentsNum * 1.0));
            Console.WriteLine($"Average points: {avaragePointsForTournament}");

            double percentageWins = (winsCounter / (tournamentsNum * 1.0)) * 100.00;
            Console.WriteLine($"{percentageWins:f2}%");
        }
    }
}
