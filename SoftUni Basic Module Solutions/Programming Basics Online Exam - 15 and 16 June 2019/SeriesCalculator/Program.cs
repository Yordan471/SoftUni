using System;

namespace SeriesCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string seriesName = Console.ReadLine();
            int numSeasons = int.Parse(Console.ReadLine());
            int episodes = int.Parse(Console.ReadLine());
            double lengthOfOneNormalEpisode = double.Parse(Console.ReadLine());

            double minutesEpisodes = episodes * lengthOfOneNormalEpisode + (episodes * 0.20 * lengthOfOneNormalEpisode);
            double totalMinutes = numSeasons * minutesEpisodes + numSeasons * 10;

            Console.WriteLine($"Total time needed to watch the {seriesName} series is {totalMinutes} minutes.");
        }
    }
}
