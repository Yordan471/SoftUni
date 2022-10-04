using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());

            List<string> guestsGoing = new List<string>();

            for (int i = 1; i <= numberOfCommands; i++)
            {
                string command = Console.ReadLine();

                List<string> listCommand = command
                    .Split()
                    .ToList();
                string checkIfIsOrNot = string.Empty;

                if (listCommand.Count == 4)
                {
                    checkIfIsOrNot = listCommand[2];
                }
                else
                {
                    checkIfIsOrNot = listCommand[1];
                }

                string nameOfGuest = listCommand[0];

                if (checkIfIsOrNot == "is")
                {
                    if (guestsGoing.Contains(nameOfGuest))
                    {
                        Console.WriteLine($"{nameOfGuest} is already in the list");
                    }
                    else
                    {
                        guestsGoing.Add(nameOfGuest); 
                    }
                }
                else if (checkIfIsOrNot == "not")
                {
                    if (guestsGoing.Contains(nameOfGuest))
                    {
                        guestsGoing.Remove(nameOfGuest);
                    }
                    else
                    {
                        Console.WriteLine($"{nameOfGuest} is not in the list!");
                    }
                }
            }

            Console.WriteLine(String.Join(Environment.NewLine, guestsGoing));   
        }
    }
}
