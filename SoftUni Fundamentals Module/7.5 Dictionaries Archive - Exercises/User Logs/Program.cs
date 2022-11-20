using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace User_Logs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] separators= { '=', ' ' };

            Dictionary <string, List<string>> nameAndIP = new Dictionary<string, List<string>>();
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandToArray = command
                    .Split(separators);

                string IP = commandToArray[1];
                string name = commandToArray[5];

                if (!nameAndIP.ContainsKey(name))
                {
                    nameAndIP.Add(name, new List<string>());
                }

                nameAndIP[name].Add(IP);
            }

            foreach (var nameIP in nameAndIP.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{nameIP.Key}:");
                int counter = 0;

                foreach (var IP in nameIP.Value.Distinct())
                {
                    int count = nameIP.Value.Count(x => x.Equals(IP));
                    counter++;

                    if (counter == nameIP.Value.Distinct().Count())
                    {
                        Console.WriteLine($"{IP} => {count}.");
                        break;
                    }

                    Console.Write($"{IP} => {count}, ");
                }
            }
        }
    }
}
