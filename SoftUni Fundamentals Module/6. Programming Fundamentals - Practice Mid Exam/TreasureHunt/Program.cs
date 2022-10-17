using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Runtime.ExceptionServices;

namespace TreasureHunt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] initialLoot = Console.ReadLine()
            .Split('|')
            .ToArray();

            string command = Console.ReadLine();

            while (true)
            {
                if (command == "Yohoho!")
                {
                    break;
                }

                string[] operations = command
                    .Split()
                    .ToArray();

                string operation = operations[0];
                List<string> lootedItems = new List<string>();

                if (operation == "Loot")
                {
                    LootItems(ref initialLoot, operations);

                    for (int i = 1; i < operations.Length; i++)
                    {
                        bool exists = false;

                        for (int j = 0; j < initialLoot.Length; j++)
                        {
                            if (initialLoot[j] == operations[i])
                            {
                                exists = true;
                                break;
                            }
                        }

                    }
                }
                else if (operation == "Drop")
                {
                    int index = int.Parse(operations[1]);

                    DropItem(ref initialLoot, index);
                }
                else if (operation == "Steal")
                {
                    int Count = int.Parse(operations[1]);

                    StealItems(ref initialLoot, Count);
                }

                command = Console.ReadLine();
            }

            if (initialLoot.Length > 0)
            {
                decimal sum = 0;

                for (int i = 0; i < initialLoot.Length; i++)
                {
                    sum += initialLoot[i].Length;
                }

                decimal resultSum = sum / initialLoot.Length;
                Console.WriteLine(string.Join(", ", initialLoot));
                Console.WriteLine($"Average treasure gain: {resultSum:f2} pirate credits.");
            }
            else
            {
                Console.WriteLine("Failed treasure hunt.");
            }      
        }

        static string[] LootItems(ref string[] initialLoot, string[] operations)
        {
            List<string> listInitialLoot = new List<string>();

            foreach (string item in initialLoot)
            {
                listInitialLoot.Add(item);
            }

            int countLootedItems = 0;

            for (int i = 1; i < operations.Length; i++)
            {
                bool exists = false;

                for (int j = 0; j < initialLoot.Length; j++)
                {
                    if (listInitialLoot[j] == operations[i])
                    {
                        exists = true;
                        break;
                    }
                }

                if (!exists)
                {
                    listInitialLoot.Insert(0, operations[i]);
                    countLootedItems++;
                }
            }

            initialLoot = listInitialLoot.ToArray();

            return initialLoot;          
        }

        static string[] DropItem(ref string[] initialLoot, int index)
        {
            if (index < 0 || index >= initialLoot.Length)
            {
                return initialLoot;
            }
            else
            {
                string[] saveItems = new string[initialLoot.Length];

                for (int i = 0; i < initialLoot.Length; i++)
                {
                    if (i >= index)
                    {
                        if (i == initialLoot.Length - 1)
                        {
                            saveItems[i] = initialLoot[index];
                            continue;
                        }

                        saveItems[i] = initialLoot[i + 1];
                        continue;
                    }

                    saveItems[i] = initialLoot[i];
                }

                initialLoot = saveItems;

                return initialLoot;
            }        
        }

        static string[] StealItems(ref string[] initialLoot, int count)
        {
            if (initialLoot.Length - count <= 0)
            {
                return initialLoot = new string[0];
            }
            else
            {
                string[] saveString = new string[initialLoot.Length - count];

                for (int i = 0; i < saveString.Length; i++)
                {
                    saveString[i] = initialLoot[i];
                }

                initialLoot = saveString;

                return initialLoot;
            }          
        }
    }
}
