using System;

namespace MovieDestination
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string destination = Console.ReadLine();
            string season = Console.ReadLine();
            int numDays = int.Parse(Console.ReadLine());

            double sumNeeded = 0;

            if (destination == "Dubai")
            {
                switch (season)
                {
                    case "Winter":
                        sumNeeded += 45000;
                        break;
                    case "Summer":
                        sumNeeded += 40000;
                        break;
                }
            }
            else if (destination == "Sofia")
            {
                switch (season)
                {
                    case "Winter":
                        sumNeeded += 17000;
                        break;
                    case "Summer":
                        sumNeeded += 12500;
                        break;
                }
            }
            else if (destination == "London")
            {
                if (season == "Winter")
                {
                    sumNeeded += 24000;
                }
                else if (season == "Summer")
                {
                    sumNeeded += 20250;
                }
            }

            double sumNeededForMovie = numDays * sumNeeded;

            if (destination == "Dubai")
            {
                sumNeededForMovie *= 0.70;
            }
            else if (destination == "Sofia")
            {
                sumNeededForMovie *= 1.25;
            }

            double sumAfterFinishing = Math.Abs(sumNeededForMovie - budget);

            if (sumNeededForMovie <= budget)
            {
                Console.WriteLine($"The budget for the movie is enough! We have {sumAfterFinishing:f2} leva left!");
            }
            else if (sumNeededForMovie > budget)
            {
                Console.WriteLine($"The director needs {sumAfterFinishing:f2} leva more!");
            }
        }
    }
}
