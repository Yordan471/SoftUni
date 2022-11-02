using System;
using System.Collections.Generic;
using System.Linq;

namespace SnowwhiteDiffSolution
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> nameHatColorAndPhysics =
                new Dictionary<string, int>();

            string inputInfo = string.Empty;

            while ((inputInfo = Console.ReadLine()) != "Once upon a time")
            {
                string[] inputInfoToArray = inputInfo
                    .Split(" <:> ");

                string name = inputInfoToArray[0];
                string color = inputInfoToArray[1];
                int physics = int.Parse(inputInfoToArray[2]);

                string nameAndColor = name + "-" + color;

                if (!nameHatColorAndPhysics.ContainsKey(nameAndColor))
                {
                    nameHatColorAndPhysics.Add(nameAndColor, physics);
                }
                else
                {
                    nameHatColorAndPhysics[nameAndColor] =
                        Math.Max(nameHatColorAndPhysics[nameAndColor], physics);
                }
            }

            foreach (var dwarf in nameHatColorAndPhysics
                .OrderByDescending(x => x.Value)
                .ThenByDescending(x => nameHatColorAndPhysics
                .Where(y => y.Key.Split("-")[1] == x.Key.Split("-")[1])
                .Count()))
            {
                Console.WriteLine($"({dwarf.Key.Split("-")[1]}) " +
                    $"{dwarf.Key.Split("-")[0]} " +
                    $"{dwarf.Value}");
            }        
        }
    }
}
