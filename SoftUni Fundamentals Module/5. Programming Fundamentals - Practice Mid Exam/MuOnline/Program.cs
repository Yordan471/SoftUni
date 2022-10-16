using System;
using System.Linq;
using System.Threading;

namespace MuOnline
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] dungeonRooms = Console.ReadLine()
                .Split('|')
                .ToArray();

            int counterRooms = 0;
            int initialHealth = 100;
            int bitcoins = 0;
            bool died = false;
            
            while (counterRooms != dungeonRooms.Length)
            {
                if (died)
                {
                    break;
                }

                for (int i = 0; i < dungeonRooms.Length; i++)
                {
                    counterRooms++;

                    string[] commandAndNumber = dungeonRooms[i]
                        .Split()
                        .ToArray();

                    string command = commandAndNumber[0];
                    int number = int.Parse(commandAndNumber[1]);

                    if (command == "potion")
                    {
                        if (initialHealth + number > 100)
                        {
                            number = 100 - initialHealth;
                            initialHealth = 100;
                        }
                        else
                        {
                            initialHealth += number;
                        }

                        Console.WriteLine($"You healed for {number} hp.");
                        Console.WriteLine($"Current health: {initialHealth} hp.");
                    }
                    else if (command == "chest")
                    {
                        bitcoins += number;
                        Console.WriteLine($"You found {number} bitcoins.");
                    }
                    else
                    {
                        initialHealth -= number;

                        if (initialHealth <= 0)
                        {
                            Console.WriteLine($"You died! Killed by {command}.");
                            died = true;
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"You slayed {command}.");
                        }
                    }
                }
            }

            if (died)
            {
                Console.WriteLine($"Best room: {counterRooms}");
            }
            else
            {
                Console.WriteLine($"You've made it!");
                Console.WriteLine($"Bitcoins: {bitcoins}");
                Console.WriteLine($"Health: {initialHealth}");
            }
        }
    }
}
