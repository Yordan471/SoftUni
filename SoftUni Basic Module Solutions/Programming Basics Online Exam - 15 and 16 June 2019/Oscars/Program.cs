using System;

namespace Oscars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string actorName = Console.ReadLine();
            double pointsFromTheAcademy = double.Parse(Console.ReadLine());
            int numPeople = int.Parse(Console.ReadLine());

            bool isEnough = false;

            for (int i = 1; i <= numPeople; i++)
            {
                string personName = Console.ReadLine();
                double pointsFromThePerson = double.Parse(Console.ReadLine());

                double pointsGathered = (personName.Length * pointsFromThePerson) / 2;
                pointsFromTheAcademy += pointsGathered;

                if (pointsFromTheAcademy > 1250.5)
                {
                    isEnough = true;
                    break;
                }
            }

            if (isEnough)
            {
                Console.WriteLine($"Congratulations, {actorName} got a nominee for leading role with {pointsFromTheAcademy:f1}!");
            }
            else
            {
                double pointsNeeded = 1250.5 - pointsFromTheAcademy;
                Console.WriteLine($"Sorry, {actorName} you need {pointsNeeded:f1} more!");
            }
        }
    }
}
