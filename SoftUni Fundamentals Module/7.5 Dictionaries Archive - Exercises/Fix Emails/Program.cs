using System;
using System.Collections.Generic;

namespace Fix_Emails
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;

            Dictionary<string, string> nameAndEmail = new Dictionary<string, string>();

            while ((command = Console.ReadLine()) != "stop")
            {
                string name = command;
                string email = Console.ReadLine();

                if (!nameAndEmail.ContainsKey(name))
                {
                    nameAndEmail[name] = email;
                }
                else
                {
                    nameAndEmail[name] = email;
                }
                
            }

            foreach (var kvp in nameAndEmail)
            {
                if (kvp.Value.Contains(".uk") || kvp.Value.Contains(".us"))
                {
                    continue;
                }

                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
