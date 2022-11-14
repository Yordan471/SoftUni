using System;
using System.Collections.Generic;

namespace Pirates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;

            Dictionary <string, int> cityAndPopulation = new Dictionary<string, int>();
            Dictionary <string, int> cityAndGold= new Dictionary<string, int>();

            while ((command = Console.ReadLine()) != "Sail")
            {
                string[] targetCityInfo = command
                    .Split("||");

                string cityName = targetCityInfo[0];
                int population = int.Parse(targetCityInfo[1]);
                int gold = int.Parse(targetCityInfo[2]);

                if (!cityAndGold.ContainsKey(cityName))
                {
                    cityAndGold[cityName] = gold;
                    cityAndPopulation[cityName] = population;
                }
                else
                {
                    cityAndGold[cityName] += gold;
                    cityAndPopulation[cityName] += population;
                }
            }

            string inputArgs = string.Empty;

            while ((inputArgs = Console.ReadLine()) != "End")
            {
                string[] inputCommands = inputArgs
                    .Split("=>");

                string operation = inputCommands[0];

                if (operation == "Plunder")
                {
                    string town = inputCommands[1];
                    int people = int.Parse(inputCommands[2]);
                    int gold = int.Parse(inputCommands[3]);

                    if (cityAndGold[town] - gold == 0 || cityAndPopulation[town] - people == 0)
                    {
                        cityAndGold.Remove(town);
                        cityAndPopulation.Remove(town);
                        Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");
                        Console.WriteLine($"{town} has been wiped off the map!");
                    }
                    else
                    {
                        cityAndGold[town] -= gold;
                        cityAndPopulation[town] -= people;
                        Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");
                    }
                }
                else if (operation == "Prosper")
                {
                    string town = inputCommands[1];
                    int gold = int.Parse(inputCommands[2]);

                    if (gold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                    }
                    else
                    {
                        cityAndGold[town] += gold;
                        Console.WriteLine($"{gold} gold added to the city treasury. " +
                            $"{town} now has {cityAndGold[town]} gold.");
                    }
                }
            }

            if (cityAndGold.Count == 0)
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
            else
            {
                Console.WriteLine($"Ahoy, Captain! There are {cityAndGold.Count} wealthy settlements to go to:");

                foreach (var cityGold in cityAndGold)
                {
                    foreach (var cityPopulation in cityAndPopulation)
                    {
                        if (cityPopulation.Key == cityGold.Key)
                        {
                            Console.WriteLine($"{cityGold.Key} -> Population: {cityPopulation.Value} citizens, " +
                                $"Gold: {cityGold.Value} kg");
                            break;
                        }                    
                    }
                }
            }
        }
    }
}
