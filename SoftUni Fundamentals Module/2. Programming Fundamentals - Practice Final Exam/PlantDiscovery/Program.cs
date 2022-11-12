using System;
using System.Collections.Generic;
using System.Linq;

namespace PlantDiscovery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rotation = int.Parse(Console.ReadLine());

            Dictionary <string, string> plantRarity = new Dictionary<string, string>();
            Dictionary<string, List<int>> plantRating = new Dictionary<string, List<int>>();

            for (int i = 0; i < rotation; i++)
            {
                string[] inputInfo = Console.ReadLine()
                    .Split("<->");

                string plant = inputInfo[0];
                string rarity = inputInfo[1];

                if (!plantRarity.ContainsKey(plant))
                {
                    plantRating[plant] = new List<int>(); 
                    plantRarity[plant] = rarity;
                }
                else if (plantRarity[plant] != rarity)
                {
                    plantRarity[plant] = rarity;
                }             
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Exhibition")
            {
                string[] separator = { ": ", " - " };
                string[] commandToArray = command
                    .Split(separator, StringSplitOptions.RemoveEmptyEntries);

                string operation = commandToArray[0];

                if (operation == "Rate")
                {
                    string plant = commandToArray[1];
                    int rating = int.Parse(commandToArray[2]);

                    if (plantRating.ContainsKey(plant))
                    {
                        plantRating[plant].Add(rating);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (operation == "Update")
                {
                    string plant = commandToArray[1];
                    string newRarity = commandToArray[2];

                    if (plantRarity.ContainsKey(plant) &&
                        plantRarity[plant] != newRarity)
                    {
                        plantRarity[plant] = newRarity;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (operation == "Reset")
                {
                    string plant = commandToArray[1];

                    if (plantRating.ContainsKey(plant))
                    {
                        plantRating[plant].Clear();
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
            }

            Console.WriteLine("Plants for the exhibition:");

            foreach (var plant in plantRarity)
            {
                double avrgSum = 0;

                    if (plantRating[plant.Key].Count == 0)
                    {
                        avrgSum = 0;
                    }
                    else
                    {
                        avrgSum = plantRating[plant.Key].Average();
                    }

                    Console.WriteLine($"{plant.Key}; Rarity: {plant.Value}; Rating: {avrgSum:F2}");                                
            }
        }
    }
}
