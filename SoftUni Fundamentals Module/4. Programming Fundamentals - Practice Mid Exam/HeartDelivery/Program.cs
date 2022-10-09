using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeartDelivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> listOfIntegers = Console.ReadLine()
                .Split('@')
                .Select(int.Parse)
                .ToList();
            string command = Console.ReadLine();
            int lastPosition = 0;

            while (true)
            {
                if (command == "Love!")
                {
                    break;
                }

                List<string> commandToList = command
                    .Split()
                    .ToList();

                int index = int.Parse(commandToList[1]);

                if (index + lastPosition > listOfIntegers.Count - 1)
                {
                    if (listOfIntegers[0] == 0)
                    {
                        Console.WriteLine("Place 0 already has Valentine's day.");
                        lastPosition = 0;
                        index = 0;
                    }
                    else
                    {
                        listOfIntegers[0] -= 2;

                        if (listOfIntegers[0] == 0)
                        {
                            Console.WriteLine($"Place 0 has Valentine's day.");
                        }

                        lastPosition = 0;
                        index = 0;
                    }
                }
                else
                {
                    if (listOfIntegers[lastPosition + index] == 0)
                    {
                        Console.WriteLine($"Place {index + lastPosition} already has Valentine's day.");
                    }
                    else
                    {
                        listOfIntegers[index + lastPosition] -= 2;

                        if (listOfIntegers[index + lastPosition] == 0)
                        {
                            Console.WriteLine($"Place {index + lastPosition} has Valentine's day");
                        }
                    }
                }

                lastPosition = index + lastPosition;
                command = Console.ReadLine();
            }

            int countHouses = 0;

            for (int i = 0; i < listOfIntegers.Count; i++)
            {
                if (listOfIntegers[i] == 0)
                {
                    countHouses++;
                }
            }

            if (countHouses == listOfIntegers.Count)
            {
                Console.WriteLine($"Cupid's last position was {lastPosition}.");
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Cupid's last position was {lastPosition}.");
                Console.WriteLine($"Cupid has failed {listOfIntegers.Count - countHouses} places.");
            }
        }
    }
}
