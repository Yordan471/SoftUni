using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string playerName = Console.ReadLine();
            string text = Console.ReadLine();

            int sumPoints = 0;
            int startingPoints = 301;
            int counter = 0;
            int counterUnsuccessful = 0;
            int savedPoints = 0;
            bool wonLeg = false;
            bool retire = false;

            while (text != "Retire")
            {
                int points = int.Parse(Console.ReadLine());

                counter++;

                if (text == "Single")
                {
                    sumPoints += points;
                    savedPoints = points;
                }
                else if (text == "Double")
                {
                    sumPoints += 2 * points;
                    savedPoints = 2 * points;
                }
                else if (text == "Triple")
                {
                    sumPoints += 3 * points;
                    savedPoints = 3 * points;
                }

                if (sumPoints == startingPoints)
                {
                    wonLeg = true;
                    break;
                }
                else if (sumPoints > startingPoints)
                {
                    sumPoints -= savedPoints;
                    counterUnsuccessful++;
                    counter--;
                }

                text = Console.ReadLine();

                if (text == "Retire")
                {
                    retire = true;
                }
            }

            if (wonLeg)
            {
                Console.WriteLine($"{playerName} won the leg with {counter} shots.");
            }
            else if (retire)
            {
                Console.WriteLine($"{playerName} retired after {counterUnsuccessful} unsuccessful shots.");
            }
        }
    }
}
