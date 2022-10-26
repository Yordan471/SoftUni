using System;
using System.Diagnostics.Tracing;

namespace AdvertisementMessage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfMessage = int.Parse(Console.ReadLine());

            string[] phrases = { "Excellent product.", "Such a great product.", 
                "I always use that product.", "Best product of its category.", 
                "Exceptional product.", "I can’t live without this product." };

            string[] events = { "Now I feel good.", "I have succeeded with this product.", 
                "Makes miracles. I am happy of the results!", 
                "I cannot believe but now I feel awesome.", 
                "Try it yourself, I am very satisfied.", "I feel great!" };

            string[] authors = { "Diana", "Petya", "Stella", "Elena", "Katya", 
                "Iva", "Annie", "Eva" };

            string[] cities = { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };


            Random randomize = new Random();
            
            for (int i = 1; i <= numberOfMessage; i++)
            {
                string randomPhrase = phrases[randomize.Next(0, 6)];
                string randomEvent = events[randomize.Next(0, 6)];
                string randomAuthor = authors[randomize.Next(0, 8)];
                string randomCity = cities[randomize.Next(0, 5)];

                Console.WriteLine($"{randomPhrase} {randomEvent} {randomAuthor} {randomCity}");
            }
        }
    }
}
