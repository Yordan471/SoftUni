using System;
using System.Collections.Generic;

namespace A_Minor_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            Dictionary <string, int> resourceAndQuantity = new Dictionary<string, int> ();

            while ((command = Console.ReadLine()) != "stop")
            {
                string resource = command;
                int quantity = int.Parse(Console.ReadLine());


                if (!resourceAndQuantity.ContainsKey(resource))
                {
                     resourceAndQuantity.Add(resource, 0);
                }

                resourceAndQuantity[resource] += quantity;                                   
            }

            foreach (var kvp in resourceAndQuantity)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }        
        }
    }
}
