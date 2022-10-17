using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Drawing;
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

            string command = string.Empty;
            List<string> saveLootItems = new List<string>();

            while ((command = Console.ReadLine()) != "Yohoho")
            {
                if (command == "Yohoho!")
                {
                    break;
                }

                string[] operations = command
                    .Split()
                    .ToArray();

                string operation = operations[0];

                if (operation == "Loot")
                {
                    string firstItem = initialLoot[0];

                    LootItems(ref initialLoot, operations);

                    for (int i = 0; i < operations.Length; i++)
                    {
                        if (initialLoot[i] == firstItem)
                        {
                            break;
                        }

                        saveLootItems.Add(initialLoot[i]);
                    }
                }
                else if (operation == "Drop")
                {
                    int index = int.Parse(operations[1]);

                    if (index < 0 || index >= initialLoot.Length)
                    {
                        continue;
                    }

                    DropItem(ref initialLoot, index);
                }
                else if (operation == "Steal")
                {
                    int count = int.Parse(operations[1]);

                    if (initialLoot.Length <= count)
                    {
                        PrintStolenItems(ref initialLoot, count);
                        initialLoot = new string[0];
                    }
                    else
                    {
                        PrintStolenItems(ref initialLoot, count);
                        StealItems(ref initialLoot, count);
                    }
                }
            }

            if (initialLoot.Length > 0)
            {
                decimal sum = 0;

                for (int i = 0; i < initialLoot.Length; i++)
                {
                    sum += initialLoot[i].Length;
                }

                decimal resultSum = sum / initialLoot.Length;
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
            bool exists = false;

            for (int i = 0; i < initialLoot.Length; i++)
            {
                listInitialLoot.Add(initialLoot[i]);
            }

            for (int i = 1; i < operations.Length; i++)
            {
                exists = false;

                for (int j = 0; j < initialLoot.Length; j++)
                {
                    if (initialLoot[j] == operations[i])
                    {
                        exists = true;
                        break;
                    }
                }

                if (!exists)
                {
                   listInitialLoot.Insert(0, operations[i]);
                }
            }

            return initialLoot = listInitialLoot.ToArray();
        }

        static string[] DropItem(ref string[] initialLoot, int index)
        {
            string[] saveInitialLoot = new string[initialLoot.Length];

            for (int i = 0; i < initialLoot.Length; i++)
            {
                if (i == initialLoot.Length - 1)
                {
                    saveInitialLoot[i] = initialLoot[index];
                    break;
                }

                if (i >= index)
                {
                    saveInitialLoot[i] = initialLoot[i + 1];
                }
                else
                {
                    saveInitialLoot[i] = initialLoot[i];
                }
            }

            return initialLoot = saveInitialLoot;          
        }

        static string[] StealItems(ref string[] initialLoot, int count)
        {
            string[] saveInitialLoot = new string[initialLoot.Length - count];

            for (int i = 0; i < saveInitialLoot.Length; i++)
            {
                saveInitialLoot[i] = initialLoot[i];
            }

            return initialLoot = saveInitialLoot;
        }

        static void PrintStolenItems(ref string[] initialLoot, int count)
        {
            if (initialLoot.Length - count <= 0)
            {
                for (int j = 0; j < initialLoot.Length; j++)
                {
                    if (j == initialLoot.Length - 1)
                    {
                        Console.Write($"{initialLoot[j]}");
                        continue;
                    }

                    Console.Write($"{initialLoot[j]}, ");
                }
            }
            else
            {
                for (int i = initialLoot.Length - count; i < initialLoot.Length; i++)
                {
                    if (i == initialLoot.Length - 1)
                    {
                        Console.Write($"{initialLoot[i]}");
                        continue;
                    }

                    Console.Write($"{initialLoot[i]}, ");
                }
            }
        }
    }
}
