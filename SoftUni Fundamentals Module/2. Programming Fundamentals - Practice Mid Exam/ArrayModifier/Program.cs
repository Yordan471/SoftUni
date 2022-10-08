using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ArrayModifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arrayOfIntegers = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();
            string command = Console.ReadLine();

            while (true)
            {
                if (command == "end")
                {
                    break;
                }

                string[] commandArray = command
                    .Split()
                    .ToArray();

                string operation = commandArray[0];

                if (operation == "swap" || operation == "multiply")
                {
                    int indexOne = int.Parse(commandArray[1]);
                    int indexTwo = int.Parse(commandArray[2]);

                    if (operation == "swap")
                    {
                        int saveIndexOne = arrayOfIntegers[indexOne];
                        arrayOfIntegers[indexOne] = arrayOfIntegers[indexTwo];
                        arrayOfIntegers[indexTwo] = saveIndexOne;
                    }
                    else
                    {
                        arrayOfIntegers[indexOne] = arrayOfIntegers[indexOne] * arrayOfIntegers[indexTwo];
                    }
                }
                else if (operation == "decrease")
                {
                    for (int i = 0; i <= arrayOfIntegers.Length - 1; i++)
                    {
                        arrayOfIntegers[i] -= 1;
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(String.Join(", ", arrayOfIntegers));
        }
    }
}
