using System;

namespace OscarsWeekInCinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string movieName = Console.ReadLine();
            string hallType = Console.ReadLine();
            int numTickets = int.Parse(Console.ReadLine());

            double sum = 0;

            if (movieName == "A Star Is Born")
            {
                switch (hallType)
                {
                    case "normal":
                        sum += 7.50; break;
                    case "luxury":
                        sum += 10.50; break;
                    case "ultra luxury":
                        sum += 13.50; break;
                }
            }
            else if (movieName == "Bohemian Rhapsody")
            {
                switch (hallType)
                {
                    case "normal":
                        sum += 7.35; break;
                    case "luxury":
                        sum += 9.45; break;
                    case "ultra luxury":
                        sum += 12.75; break;
                }
            }
            else if (movieName == "Green Book")
            {
                switch (hallType)
                {
                    case "normal":
                        sum += 8.15; break;
                    case "luxury":
                        sum += 10.25; break;
                    case "ultra luxury":
                        sum += 13.25; break;
                }
            }
            else if (movieName == "The Favourite")
            {
                switch (hallType)
                {
                    case "normal":
                        sum += 8.75; break;
                    case "luxury":
                        sum += 11.55; break;
                    case "ultra luxury":
                        sum += 13.95; break;
                }
            }

            double income = sum * numTickets;
            Console.WriteLine($"{movieName} -> {income:f2} lv.");
        }
    }
}
