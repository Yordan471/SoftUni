﻿using System;
using System.Collections.Generic;

namespace Phonebook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;

            Dictionary<string, string> nameAndPhone = new Dictionary<string, string>();

            while ((command = Console.ReadLine()) != "END")
            {
                string[] commandToArray = command
                    .Split(' ');

                string operation = commandToArray[0];
                
                if (operation == "A")
                {
                    string name = commandToArray[1];
                    string number = commandToArray[2];

                    if (!nameAndPhone.ContainsKey(name))
                    {
                        nameAndPhone[name] = number;
                    }

                    nameAndPhone[name] = number;
                }
                else if (operation == "S")
                {
                    string name = commandToArray[1];

                    if (nameAndPhone.ContainsKey(name))
                    {
                        Console.WriteLine($"{name} -> {nameAndPhone[name]}");
                    }
                    else
                    {
                        Console.WriteLine($"Contact {name} does not exist.");
                    }
                }
            }
        }
    }
}
