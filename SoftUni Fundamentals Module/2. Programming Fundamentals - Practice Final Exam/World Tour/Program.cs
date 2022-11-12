using System;
using System.Collections.Generic;
using System.Linq;

namespace World_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string tourStops = Console.ReadLine();
            string[] sep = { "::", "-", ":" };
            string[] inputToArray = tourStops
                .Split(sep, StringSplitOptions.RemoveEmptyEntries);

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Travel")
            {
                string[] commandToArray = command
                    .Split(':');

                string operation = commandToArray[0];

                if (operation == "Add Stop")
                {
                    int index = int.Parse(commandToArray[1]);
                    string substring = commandToArray[2];

                    if (index >= 0 && index <= tourStops.Length)
                    {
                        tourStops = tourStops.Insert(index, substring);
                        Console.WriteLine(tourStops);
                    }         
                }
                else if (operation == "Remove Stop")
                {
                    int startIndex = int.Parse(commandToArray[1]);
                    int endIndex = int.Parse(commandToArray[2]);

                    if ((startIndex >= 0 && startIndex <= tourStops.Length) &&
                        (endIndex >= 0 && endIndex <= tourStops.Length))
                    {
                        int length = endIndex - startIndex;
                        tourStops = tourStops.Remove(startIndex, length + 1);
                        Console.WriteLine(tourStops);
                    }
                }
                else
                {
                    string oldString = commandToArray[1];
                    string newString = commandToArray[2];
                    string[] separator = { "::", "-", ":" };
                    List<string> tourToList = tourStops
                        .Split(separator, StringSplitOptions.RemoveEmptyEntries)
                        .ToList();

                    if (inputToArray.Contains(oldString))
                    {
                        tourStops = tourStops.Replace(oldString, newString);
                        Console.WriteLine(tourStops);
                    }
    
                }
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {tourStops}");
        }
    }
}
