using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;

namespace ManOWar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> statusPirateShip = Console.ReadLine()
                .Split('>')
                .Select(int.Parse)
                .ToList();
            List<int> statusWarship = Console.ReadLine()
                .Split('>')
                .Select(int.Parse)
                .ToList();
            int maxHealthForSection = int.Parse(Console.ReadLine());

            bool endProgram = false;
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Retire")
            {
                if (command == "Retire")
                {
                    break;
                }

                List<string> commandToList = command
                    .Split()
                    .ToList();

                string operation = commandToList[0];

                if (operation == "Fire")
                {
                    int index = int.Parse(commandToList[1]);
                    int damage = int.Parse(commandToList[2]);

                    if (index < 0 || index >= statusWarship.Count)
                    {
                        continue;
                    }

                    FireOperation(statusWarship, index, damage);

                    if (statusWarship[index] <= 0)
                    {
                        Console.WriteLine($"You won! The enemy ship has sunken.");
                        endProgram = true;
                        return;
                    }
                }
                else if (operation == "Defend")
                {
                    int startIndex = int.Parse(commandToList[1]);
                    int endIndex = int.Parse(commandToList[2]);
                    int damage = int.Parse(commandToList[3]);

                    if (startIndex < 0 || endIndex >= statusPirateShip.Count)
                    {
                        continue;
                    }

                    DefendOperation(statusPirateShip, startIndex, endIndex, damage);

                    for (int i = startIndex; i < endIndex; i++)
                    {
                        if (statusPirateShip[i] <= 0)
                        {
                            Console.WriteLine($"You lost! The pirate ship has sunken.");
                            endProgram = true;
                            return;
                        }
                    }
                }
                else if (operation == "Repair")
                {
                    int index = int.Parse(commandToList[1]);
                    int health = int.Parse(commandToList[2]);

                    HealthOperation(statusPirateShip, index, health, maxHealthForSection);
                }
                else if (operation == "Status")
                {
                    int countSectionsToRepair = 0;

                    StatusOperation(statusPirateShip, maxHealthForSection,ref countSectionsToRepair);

                    Console.WriteLine($"{countSectionsToRepair} sections need repair.");
                }

            } 
            
            if (!endProgram)
            {
                int pirateShipSum = statusPirateShip.Sum();
                int warshipSum = statusWarship.Sum();

                Console.WriteLine($"Pirate ship status: {pirateShipSum}");
                Console.WriteLine($"Warship status: {warshipSum}");
            }          
        }

        static List<int> FireOperation(List<int> statusWarship, int index, int damage)
        {
            if (index >= 0 && index < statusWarship.Count)
            {
                statusWarship[index] -= damage;
            }

            return statusWarship;
        }
    
        static List<int> DefendOperation(List<int> statusPirateShip, int startIndex, int endIndex, int damage)
        {
            if (startIndex >= 0 && endIndex < statusPirateShip.Count)
            {
                for (int i = startIndex; i <= endIndex; i++)
                {
                    statusPirateShip[i] -= damage;
                }
            }

            return statusPirateShip;
        }

        static List<int> HealthOperation(List<int> statusPirateShip, int index, int health, int maxHealthForSection)
        {
            if (index >= 0 && index < statusPirateShip.Count)
            {
                statusPirateShip[index] += health;

                if (statusPirateShip[index] > maxHealthForSection)
                {
                    statusPirateShip[index] = maxHealthForSection;
                }
            }

            return statusPirateShip;
        }

        static int StatusOperation(List<int> statusPirateShip, int maxHealthForSection,ref int countSectionsToRepair)
        {
            decimal prctngOfMaxHealth = 0.20M * maxHealthForSection * 1.0M;


            for (int i = 0; i < statusPirateShip.Count; i++)
            {
                if (statusPirateShip[i] < prctngOfMaxHealth)
                {
                    countSectionsToRepair++;
                }
            }

            return countSectionsToRepair;
        }
    }
}
