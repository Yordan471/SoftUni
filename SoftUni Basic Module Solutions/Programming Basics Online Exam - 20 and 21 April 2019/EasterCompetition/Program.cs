using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasterCompetition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberEasterCakes = int.Parse(Console.ReadLine());

            int sumPoints = 0;
            int saveSumPoints = 0;
            string saveNameBaker = "";

            for (int i = 1; i <= numberEasterCakes; i++)
            {
                string nameBaker = Console.ReadLine();

                while (true)
                {
                    string command = Console.ReadLine();

                    if (command == "Stop")
                    { 
                        break;
                    }

                    int points = int.Parse(command);

                    sumPoints += points;
                }

                Console.WriteLine($"{nameBaker} has {sumPoints} points.");

                if (saveSumPoints < sumPoints)
                {
                    saveSumPoints = sumPoints;
                    Console.WriteLine($"{nameBaker} is the new number 1!");
                    saveNameBaker = nameBaker;
                }

                sumPoints = 0;
            }

            Console.WriteLine($"{saveNameBaker} won competition with {saveSumPoints} points!");
        }
    }
}
