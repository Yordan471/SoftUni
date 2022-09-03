using System;

namespace MovieDay
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int timeForPictures = int.Parse(Console.ReadLine());
            int scenes = int.Parse(Console.ReadLine());
            int lengthOfAScene = int.Parse(Console.ReadLine());

            double preparing = timeForPictures * 0.85;
            double picturesForScenes = preparing - (scenes * lengthOfAScene);


            if (picturesForScenes >= 0)
            {
                Console.WriteLine($"You managed to finish the movie on time! You have {Math.Round(picturesForScenes)} minutes left!");
            }
            else
            {
                picturesForScenes = Math.Abs(picturesForScenes);
                Console.WriteLine($"Time is up! To complete the movie you need {Math.Round(picturesForScenes)} minutes.");
            }
        }
    }
}
