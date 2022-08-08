using System;

namespace Oscars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string actorName = Console.ReadLine();
            double lastYearsPoints = double.Parse(Console.ReadLine());
            int juryMembersNum = int.Parse(Console.ReadLine());

            double finalPoints = lastYearsPoints;

            for (int i = 1; i<= juryMembersNum; i++)
            {
                string juryMemName = Console.ReadLine();
                double points = double.Parse(Console.ReadLine());

                double totalMemberPoints = juryMemName.Length * points / 2;

                finalPoints += totalMemberPoints;

                if (finalPoints > 1250.5)
                {
                    break;
                }
            }
            if (finalPoints > 1250.5)
            {
                Console.WriteLine($"Congratulations, {actorName} got a nominee for leading role with {finalPoints:f1}!");
            }
            else
            {
                double insufficient = 1250.5 - finalPoints;
                Console.WriteLine($"Sorry, {actorName} you need {insufficient:f1} more!");
            }    
        }
    }
}
