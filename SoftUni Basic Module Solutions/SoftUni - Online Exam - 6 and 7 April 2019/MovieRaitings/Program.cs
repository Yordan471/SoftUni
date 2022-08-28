using System;

namespace MovieRaitings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numMovies = int.Parse(Console.ReadLine());
            double sumRating = 0;
            double avrgRating = 0;
            double minValue = 1000000;
            double maxValue = -1000000;
            string highestScoreMovie = "";
            string lowestScoreMovie = "";

            for (int i = 1; i <= numMovies; i++)
            {
                string nameOfMovie = Console.ReadLine();
                double rating = double.Parse(Console.ReadLine());

                sumRating += rating;

                if (rating > maxValue)
                {
                    maxValue = rating;
                    highestScoreMovie = nameOfMovie;
                }
                else if (rating < minValue)
                {
                    minValue = rating;
                    lowestScoreMovie = nameOfMovie;
                }
            }

            Console.WriteLine($"{highestScoreMovie} is with highest rating: {maxValue:f1}");
            Console.WriteLine($"{lowestScoreMovie} is with lowest rating: {minValue:f1}");

            avrgRating = sumRating / numMovies;
            Console.WriteLine($"Average rating: {avrgRating:f1}");
        }
    }
}
