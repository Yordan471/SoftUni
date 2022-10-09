using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingTarget
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> sequenceOfTargets = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            string command = Console.ReadLine();

            while (true)
            {
                if (command == "End")
                {
                    break;
                }

                List<string> commandToList = command
                    .Split()
                    .ToList();

                string operation = commandToList[0];
                int index = int.Parse(commandToList[1]);

                if (operation == "Shoot")
                {
                    int power = int.Parse(commandToList[2]);

                    sequenceOfTargets = ShootTargets(sequenceOfTargets, index, power);
                }
                else if (operation == "Add")
                {
                    int value = int.Parse(commandToList[2]);

                    if (index >= 0 && index < sequenceOfTargets.Count)
                    {
                        sequenceOfTargets.Insert(index, value);
                    }
                    else
                    {
                        Console.WriteLine("Invalid placement!");
                    }
                }
                else if (operation == "Strike")
                {
                    int radius = int.Parse(commandToList[2]);

                    if (index >= 0 && index < sequenceOfTargets.Count)
                    {
                        if (index + radius <= sequenceOfTargets.Count - 1 &&
                            index - radius >= 0)
                        {
                            for (int i = index + radius; i >= index - radius; i--)
                            {
                                sequenceOfTargets.RemoveAt(i);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Strike missed!");
                        }
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(String.Join("|", sequenceOfTargets));
        }

        static List<int> ShootTargets(List<int> sequenceOfTargets, int index, int power)
        {
            if (index >= 0 && index < sequenceOfTargets.Count)
            {
                sequenceOfTargets[index] -= power;

                if (sequenceOfTargets[index] <= 0)
                {
                    sequenceOfTargets.RemoveAt(index);
                }
            }
                    
            return sequenceOfTargets;
        }       
    }
}
