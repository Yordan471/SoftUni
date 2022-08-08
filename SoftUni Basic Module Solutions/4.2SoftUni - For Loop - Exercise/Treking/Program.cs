using System;

namespace Treking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int groupNum = int.Parse(Console.ReadLine());

            int goingToMusala = 0; int goingToMonthlanc = 0;
            int goingToKili = 0; int goingToK2 = 0; int goingToEverest = 0;

            int allPeople = 0;

            for (int i = 1; i <= groupNum; i++)
            {
                int peopleInGroupNum = int.Parse(Console.ReadLine());
                allPeople += peopleInGroupNum;//събираме всички хора

                if (peopleInGroupNum >= 1 && peopleInGroupNum <= 5)
                {
                    goingToMusala += peopleInGroupNum;// събираме хора по отделно
                }
                else if (peopleInGroupNum >= 6 && peopleInGroupNum <= 12)
                {
                    goingToMonthlanc += peopleInGroupNum;
                }
                else if (peopleInGroupNum >= 13 && peopleInGroupNum <= 25)
                {
                    goingToKili += peopleInGroupNum;
                }
                else if (peopleInGroupNum >=26 && peopleInGroupNum <= 40)
                {
                    goingToK2 += peopleInGroupNum;
                }
                else if (peopleInGroupNum >= 41)
                {
                    goingToEverest += peopleInGroupNum;
                }
            }
            double percentageMusala = (goingToMusala / (allPeople * 1.0)) * 100.00;// пробразуваме 1 от числата в дробно.
            Console.WriteLine($"{percentageMusala:f2}%");

            double percentageMonthlanc = (goingToMonthlanc / (allPeople * 1.0)) * 100.00;
            Console.WriteLine($"{percentageMonthlanc:f2}%");

            double percentageKili = (goingToKili / (allPeople * 1.0)) * 100.00;
            Console.WriteLine($"{percentageKili:f2}%");

            double percentageK2 = (goingToK2 / (allPeople * 1.0)) * 100.00;
            Console.WriteLine($"{percentageK2:f2}%");

            double percentageEverest = (goingToEverest / (allPeople * 1.00)) * 100.00;
            Console.WriteLine($"{percentageEverest:f2}%");
        }
    }
}
