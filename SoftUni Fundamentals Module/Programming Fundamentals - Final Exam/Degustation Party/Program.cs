using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Degustation_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;

            Dictionary <string, List<string>> likeGuestAndMeal = new Dictionary<string, List<string>>();

            int dislikedCounter = 0;

            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] commandToArray = command
                    .Split('-');

                string operation = commandToArray[0];

                if (operation == "Like")
                {
                    string guest = commandToArray[1];
                    string meal = commandToArray[2];

                    if (!likeGuestAndMeal.ContainsKey(guest))
                    {
                        likeGuestAndMeal[guest] = new List<string>() { meal };
                    }
                    else
                    {
                        if (!likeGuestAndMeal[guest].Contains(meal))
                        {
                            likeGuestAndMeal[guest].Add(meal);
                        }
                    }                  
                }
                else if (operation == "Dislike")
                {
                    string guest = commandToArray[1];
                    string meal = commandToArray[2];

                    if (!likeGuestAndMeal.ContainsKey(guest))
                    {
                        Console.WriteLine($"{guest} is not at the party.");
                    }
                    else if (!likeGuestAndMeal[guest].Contains(meal))
                    {
                        Console.WriteLine($"{guest} doesn't have the {meal} in his/her collection.");
                    }
                    else if (likeGuestAndMeal[guest].Contains(meal))
                    {
                        likeGuestAndMeal[guest].Remove(meal);
                        dislikedCounter++;
                        Console.WriteLine($"{guest} doesn't like the {meal}.");
                    }                            
                }
            }

            if (likeGuestAndMeal.Count > 0)
            {
                foreach (var guestMeal in likeGuestAndMeal)
                {
                    Console.Write($"{guestMeal.Key}: ");
                    Console.WriteLine(string.Join(", ", guestMeal.Value));
                }
            }

            Console.WriteLine($"Unliked meals: {dislikedCounter}");
        }
    }
}
