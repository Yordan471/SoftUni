using System;

namespace FavoriteMovie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double sum = 0;
            double saveSum = 0;
            int counter = 0;
            string saveMovieName = "";
            bool equalSeven = false;
            bool stop = false;

            while (true)
            {
                string command = Console.ReadLine();

                counter++;

                if (command == "STOP")
                {
                    stop = true;
                    break;
                }

                string movieName = command;

                for (int i = 0; i < movieName.Length; i++)
                {
                    char letter = movieName[i];

                    sum += letter;

                    if (letter >= 97 && letter <= 122)
                    {
                        sum -= 2 * movieName.Length;
                    }
                    else if (letter >= 65 && letter <= 90)
                    {
                        sum -= movieName.Length;
                    }
                }

                if (saveSum < sum)
                {
                    saveSum = sum;
                    saveMovieName = movieName;
                }

                sum = 0;

                if (counter == 7)
                {
                    equalSeven = true;
                    break;
                }               
            }

            if (equalSeven)
            {
                Console.WriteLine($"The limit is reached.");
                Console.WriteLine($"The best movie for you is {saveMovieName} with {saveSum} ASCII sum.");
            }
            else if (stop)
            {
                Console.WriteLine($"The best movie for you is {saveMovieName} with {saveSum} ASCII sum.");
            }
        }
    }
}
