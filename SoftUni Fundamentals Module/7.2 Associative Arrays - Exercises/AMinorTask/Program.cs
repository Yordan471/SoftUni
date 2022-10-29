using System;
using System.Collections.Generic;

namespace AMinorTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            string saveMaterial = string.Empty;
            int counter = 0;
            Dictionary<string, int> materialsAndQuantity = new Dictionary<string, int>();

            while (true)
            {
                if (command == "stop")
                {
                    break;
                }
         
                counter++;

                if (counter % 2 != 0)
                {
                    if (!materialsAndQuantity.ContainsKey(command))
                    {
                        materialsAndQuantity.Add(command, 0);
                        saveMaterial = command;
                    }

                    saveMaterial = command;
                }
                else
                {
                    materialsAndQuantity[saveMaterial] += int.Parse(command);
                }

                command = Console.ReadLine();
            }

            foreach (KeyValuePair<string, int> material in materialsAndQuantity)
            {
                Console.WriteLine($"{material.Key} -> {material.Value}");
            }
        }
    }
}
