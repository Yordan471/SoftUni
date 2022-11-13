using System;
using System.Collections.Generic;

namespace Heroes_of_Code_and_Logic_VII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfHeroes = int.Parse(Console.ReadLine());

            Dictionary <string, int> heroAndHitPoints = new Dictionary<string, int>();  
            Dictionary <string, int> heroAndManaPoints = new Dictionary<string, int>(); 

            for (int i = 0; i < numberOfHeroes; i++)
            {
                string[] heroesInformation = Console.ReadLine()
                    .Split();

                string heroName = heroesInformation[0];
                int hitPoints = int.Parse(heroesInformation[1]);
                int manaPoints = int.Parse(heroesInformation[2]);

                heroAndHitPoints.Add(heroName, hitPoints);
                heroAndManaPoints.Add(heroName, manaPoints);               
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandToArray = command
                    .Split(" - ");

                string action = commandToArray[0];
                string heroName = commandToArray[1];

                if (action == "CastSpell")
                {
                    int manaPointsNeeded = int.Parse(commandToArray[2]);
                    string spellName = commandToArray[3];

                    if (manaPointsNeeded > heroAndManaPoints[heroName])
                    {
                        Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                    }
                    else
                    {
                        heroAndManaPoints[heroName] -= manaPointsNeeded;
                        Console.WriteLine($"{heroName} has successfully cast {spellName} " +
                            $"and now has {heroAndManaPoints[heroName]} MP!");
                    }
                }
                else if (action == "TakeDamage")
                {
                    int damage = int.Parse(commandToArray[2]);
                    string attacker = commandToArray[3];

                    if (damage >= heroAndHitPoints[heroName])
                    {
                        Console.WriteLine($"{heroName} has been killed by {attacker}!");
                        heroAndHitPoints.Remove(heroName);
                        heroAndManaPoints.Remove(heroName);
                    }
                    else
                    {
                        heroAndHitPoints[heroName] -= damage;
                        Console.WriteLine($"{heroName} was hit for {damage} HP by " +
                            $"{attacker} and now has {heroAndHitPoints[heroName]} HP left!");
                    }
                }
                else if (action == "Recharge")
                {
                    int amount = int.Parse(commandToArray[2]);
                    int manaRecharged = amount;

                    if (amount + heroAndManaPoints[heroName] > 200)
                    {
                        manaRecharged = 200 - heroAndManaPoints[heroName];
                        heroAndManaPoints[heroName] = 200;           
                    }
                    else
                    {
                        heroAndManaPoints[heroName] += amount;
                    }

                    Console.WriteLine($"{heroName} recharged for {manaRecharged} MP!");
                }
                else if (action == "Heal")
                {
                    int amount = int.Parse(commandToArray[2]);
                    int amountHealed = amount;

                    if (amount + heroAndHitPoints[heroName] > 100)
                    {
                        amountHealed = 100 - heroAndHitPoints[heroName];
                        heroAndHitPoints[heroName] = 100;
                    }
                    else
                    {
                        heroAndHitPoints[heroName] += amount;
                    }

                    Console.WriteLine($"{heroName} healed for {amountHealed} HP!");
                }
            }

            foreach (var heroHp in heroAndHitPoints)
            {
                foreach (var heroMp in heroAndManaPoints)
                {
                    if (heroHp.Key == heroMp.Key)
                    {
                        Console.WriteLine($"{heroMp.Key}");
                        Console.WriteLine($"  HP: {heroHp.Value}");
                        Console.WriteLine($"  MP: {heroMp.Value}");
                        break;
                    }                  
                }
            }
        }
    }
}
