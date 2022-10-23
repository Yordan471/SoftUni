using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace FiendListMaintenance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] friendsList = Console.ReadLine()
                .Split(", ")
                .ToArray();

            string command = Console.ReadLine();
            int countBlacklistedNames = 0;
            int countLostNames = 0;

            while (true)
            {
                if (command == "Report")
                {
                    break;
                }

                string[] commandToArray = command
                    .Split()
                    .ToArray();

                string operation = commandToArray[0];

                if (operation == "Blacklist")
                {
                    string name = commandToArray[1];

                    bool blackListed = false;

                    for (int i = 0; i < friendsList.Length; i++)
                    {
                        if (friendsList[i] == name)
                        {
                            friendsList[i] = "Blacklisted";
                            blackListed = true;
                        }
                    }

                    if (blackListed)
                    {
                        Console.WriteLine($"{name} was blacklisted.");
                        countBlacklistedNames++;
                    }
                    else
                    {
                        Console.WriteLine($"{name} was not found.");
                    }
                }
                else if (operation == "Error")
                {
                    int index = int.Parse(commandToArray[1]);

                    if (index >=0 && index < friendsList.Length)
                    {
                        if (friendsList[index] != "Blacklisted" &&
                            friendsList[index] != "Lost")
                        {
                            Console.WriteLine($"{friendsList[index]} was lost due to an error.");
                            friendsList[index] = "Lost";
                            countLostNames++;
                        }
                    }
                }
                else if (operation == "Change")
                {
                    int index = int.Parse(commandToArray[1]);
                    string newName = commandToArray[2];

                    if (index >= 0 && index < friendsList.Length)
                    {
                        Console.WriteLine($"{friendsList[index]} changed his username to {newName}.");
                        friendsList[index] = newName;
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Blacklisted names: {countBlacklistedNames}");
            Console.WriteLine($"Lost names: {countLostNames}");
            Console.WriteLine(string.Join(' ', friendsList));
        }
    }
}
