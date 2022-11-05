using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace DragonArmy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfDragons = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<double>>> dragonsInfo = new Dictionary<string, Dictionary<string, List<double>>>();

            for (int i = 0; i < numberOfDragons; i++)
            {
                string inputInformation = Console.ReadLine();
                string[] inputInformationToArray = inputInformation
                .Split();

                int defaultDamage = 45;
                int defaultHealth = 250;
                int defaultArmor = 10;

                string type = inputInformationToArray[0];
                string name = inputInformationToArray[1];

                double damage = inputInformationToArray[2] == "null" ? defaultDamage : 
                    double.Parse(inputInformationToArray[2]);
                double health = inputInformationToArray[3] == "null" ? defaultHealth : 
                    double.Parse(inputInformationToArray[3]);
                double armor = inputInformationToArray[4] == "null" ? defaultArmor : 
                    double.Parse(inputInformationToArray[4]);

                //if (damage == null)
                //{
                //    damage = defaultDamage;
                //}

                //if (health == null)
                //{
                //    health = defaultHealth;
                //}

                //if (armor == null)
                //{
                //    armor = defaultArmor;
                //}

                if (!dragonsInfo.ContainsKey(type))
                {
                    dragonsInfo.Add(type, new Dictionary<string, List<double>>());
                    dragonsInfo[type].Add(name, new List<double>());
                }

                dragonsInfo[type][name] = new List<double> { damage, health, armor };
            }

            foreach (var dragonType in dragonsInfo)
            {
                double avrgDamage = dragonType.Value.Values
                    .Select(x => x[0]).Sum() / dragonsInfo[dragonType.Key].Count;
                double avrgHealth = dragonType.Value.Values
                    .Select(x => x[1]).Sum() / dragonsInfo[dragonType.Key].Count;
                double avrgArmor = dragonType.Value.Values
                    .Select(x => x[2]).Sum() / dragonsInfo[dragonType.Key].Count;

                Console.WriteLine($"{dragonType.Key}::({avrgDamage:f2}/{avrgHealth:f2}/{avrgArmor:f2})");

                foreach (var dragonName in dragonType.Value.OrderBy(x => x.Key))
                {
                    Console.WriteLine($"-{dragonName.Key} -> damage: {dragonName.Value[0]}, " +
                        $"health: {dragonName.Value[1]}, armor: {dragonName.Value[2]}");
                }
            }
        }           
    }
}
