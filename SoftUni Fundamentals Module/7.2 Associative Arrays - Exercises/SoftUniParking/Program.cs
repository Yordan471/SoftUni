using System;
using System.Collections.Generic;
using System.Threading;

namespace SoftUniParking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());

            Dictionary<string, string> registrationInfo = new Dictionary<string, string>();

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] commandArgs = Console.ReadLine()
                    .Split();

                string operation = commandArgs[0];
                
                if (operation == "register")
                {
                    string username = commandArgs[1];
                    string licensePlateNumber = commandArgs[2];

                    if (!registrationInfo.ContainsKey(username))
                    {
                        registrationInfo.Add(username, licensePlateNumber);
                        Console.WriteLine($"{username} registered {licensePlateNumber} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {licensePlateNumber}");
                    }
                                     
                }
                else if (operation == "unregister")
                {
                    string username = commandArgs[1];

                    if (registrationInfo.ContainsKey(username))
                    {
                        registrationInfo.Remove(username);
                        Console.WriteLine($"{username} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                    }
                }
            }

            foreach (KeyValuePair<string, string> username in registrationInfo)
            {
                Console.WriteLine($"{username.Key} => {username.Value}");
            }
        }
    }
}
