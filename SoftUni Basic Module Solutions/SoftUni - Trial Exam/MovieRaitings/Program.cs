using System;

namespace MovieRaitings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberMovies = int.Parse(Console.ReadLine());

            double maxRaiting = -1000000;
            double minRaiting = 100000;
            double averageRaiting = 0;
            
            for (int i = 1; i <= numberMovies; i++)
            {
                string movieTitle = Console.ReadLine();
                double raiting = double.Parse(Console.ReadLine());

                if (maxRaiting < raiting)
                {
                    maxRaiting = raiting;
                }
                if (minRaiting > raiting)
                {
                    minRaiting = raiting;
                }

                averageRaiting += raiting;
            }
        }
    }
}
