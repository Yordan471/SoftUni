using System;
using System.Collections.Generic;
using System.Linq;

namespace Snowwhite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputInfo = string.Empty;

            Dictionary<string, Dictionary<string, int>> colorNameAndPhysics = 
                new Dictionary<string, Dictionary<string, int>>();

            while ((inputInfo = Console.ReadLine()) != "Once upon a time")
            {
                string[] inputInfoToArray = inputInfo
                    .Split(" <:> ", StringSplitOptions.RemoveEmptyEntries);

                string dwarfName = inputInfoToArray[0];
                string dwarfHatColor = inputInfoToArray[1];
                int dwarfPhysics = int.Parse(inputInfoToArray[2]);

                if (!colorNameAndPhysics.ContainsKey(dwarfHatColor))
                {
                    colorNameAndPhysics.Add(dwarfHatColor, new Dictionary<string, int>());
                    colorNameAndPhysics[dwarfHatColor].Add(dwarfName, dwarfPhysics);
                }
                else 
                {
                    if (!colorNameAndPhysics[dwarfHatColor].ContainsKey(dwarfName))
                    {
                        colorNameAndPhysics[dwarfHatColor].Add(dwarfName, dwarfPhysics);
                    }
                    else
                    {
                        if (colorNameAndPhysics[dwarfHatColor][dwarfName] < dwarfPhysics)
                        {
                            colorNameAndPhysics[dwarfHatColor][dwarfName] = dwarfPhysics;
                        }                       
                    }
                }
            }

            Dictionary<string, int> orderedDwarfs = 
                new Dictionary<string, int>();

            foreach (var dwarfHat in colorNameAndPhysics.OrderByDescending(c => c.Value.Count))
            {
                foreach (var dwarf in dwarfHat.Value)
                {
                    orderedDwarfs.Add($"({dwarfHat.Key}) {dwarf.Key} <-> ", dwarf.Value);
                }
            }
            foreach (var dwarf in orderedDwarfs.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{dwarf.Key}{dwarf.Value}");
            }         
        }
    }
}
