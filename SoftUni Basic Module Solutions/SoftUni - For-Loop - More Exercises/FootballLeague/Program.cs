using System;

namespace FootballLeague
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int stadiumCapacity = int.Parse(Console.ReadLine());
            int numOfFans = int.Parse(Console.ReadLine());

            int counterA = 0;
            int counterB = 0;
            int counterV = 0;
            int counterG = 0;

            for (int i = 1; i <= numOfFans; i++)
            {
                string sector = Console.ReadLine();

                switch (sector)
                {
                    case "A":
                        counterA++; break;
                    case "B":
                        counterB++; break;
                    case "V":
                        counterV++; break;
                    case "G":
                        counterG++; break;

                }    
            }

            double procentFansSectorA = counterA * 100.00 / numOfFans;
            Console.WriteLine($"{procentFansSectorA:f2}%");

            double procentFansSecotrB = counterB * 100.00 / numOfFans;
            Console.WriteLine($"{procentFansSecotrB:f2}%");

            double procentFansSectorV = counterV * 100.00 / numOfFans;
            Console.WriteLine($"{procentFansSectorV:f2}%");

            double procentFansSectorG = counterG * 100.00 / numOfFans;
            Console.WriteLine($"{procentFansSectorG:f2}%");

            double procentAllFans = numOfFans * 100.00 / stadiumCapacity;
            Console.WriteLine($"{procentAllFans:f2}%");
        }
    }
}
