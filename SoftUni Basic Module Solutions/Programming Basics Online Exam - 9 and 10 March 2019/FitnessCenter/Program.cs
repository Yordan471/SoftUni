using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numPeople = int.Parse(Console.ReadLine());

            int counterBack = 0;
            int counterChest = 0;
            int counterLegs = 0;
            int counterAbs = 0;
            int counterProteinBar = 0;
            int counterProteinShake = 0;

            for (int i = 1; i <= numPeople; i++)
            {
                string activity = Console.ReadLine();

                switch (activity)
                {
                    case "Back":
                        counterBack++;
                        break;
                    case "Chest":
                        counterChest++;
                        break;
                    case "Legs":
                        counterLegs++;
                        break;
                    case "Abs":
                        counterAbs++;
                        break;
                    case "Protein shake":
                        counterProteinShake++;
                        break;
                    case "Protein bar":
                        counterProteinBar++;
                        break;
                }
            }

            Console.WriteLine($"{counterBack} - back");
            Console.WriteLine($"{counterChest} - chest");
            Console.WriteLine($"{counterLegs} - legs");
            Console.WriteLine($"{counterAbs} - abs");
            Console.WriteLine($"{counterProteinShake} - protein shake");
            Console.WriteLine($"{counterProteinBar} - protein bar");

            int sumPeopleTraining = counterAbs + counterBack +
                counterChest + counterLegs;
            int sumPeopleToBuyProteins = counterProteinBar + counterProteinShake;

            double prcntgPeopleToTrain = (sumPeopleTraining * 1.0 * 100) / numPeople * 1.0;
            Console.WriteLine($"{prcntgPeopleToTrain:f2}% - work out");

            double prcntgPeopleToBuyProtein = (sumPeopleToBuyProteins * 1.0 * 100) / numPeople * 1.0;
            Console.WriteLine($"{prcntgPeopleToBuyProtein:f2}% - protein");

        }
    }
}
