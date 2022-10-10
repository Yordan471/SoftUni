using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arrayOfNumbers = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

            decimal firstRacerTime = 0;
            decimal secondRacerTime = 0;

            for (int i = 0; i < (arrayOfNumbers.Length / 2); i++)
            {
                firstRacerTime += arrayOfNumbers[i];

                if (arrayOfNumbers[i] == 0)
                {
                    firstRacerTime *= 0.80M;
                }
            }

            for (int i = arrayOfNumbers.Length - 1; i >= (arrayOfNumbers.Length / 2) + 1; i--)
            {
                secondRacerTime += arrayOfNumbers[i];

                if (arrayOfNumbers[i] == 0)
                {
                    secondRacerTime *= 0.80M;
                }
            }

            if (firstRacerTime < secondRacerTime)
            {
                string output = firstRacerTime.ToString("0.##");
                Console.WriteLine($"The winner is left with total time: {output}");
            }
            else
            {
                secondRacerTime.ToString("0.##");
                Console.WriteLine($"The winner is right with total time: {secondRacerTime}");
            }
        }
    }
}
