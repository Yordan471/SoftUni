using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymnastics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string country = Console.ReadLine();
            string apparatus = Console.ReadLine();

            double difficultyScore = 0;
            double realizationScore = 0;
            double score20 = 20;

            if (country == "Russia")
            {
                switch (apparatus)
                {
                    case "ribbon":
                        difficultyScore += 9.100;
                        realizationScore += 9.400;
                        break;
                    case "hoop":
                        difficultyScore += 9.300;
                        realizationScore += 9.800;
                        break;
                    case "rope":
                        difficultyScore += 9.600;
                        realizationScore += 9.000;
                        break;
                }            
            }
            else if (country == "Bulgaria")
            {
                switch (apparatus)
                {
                    case "ribbon":
                        difficultyScore += 9.600;
                        realizationScore += 9.400;
                        break;
                    case "hoop":
                        difficultyScore += 9.550;
                        realizationScore += 9.750;
                        break;
                    case "rope":
                        difficultyScore += 9.500;
                        realizationScore += 9.400;
                        break;
                }
            }
            else if (country == "Italy")
            {
                switch (apparatus)
                {
                    case "ribbon":
                        difficultyScore += 9.200;
                        realizationScore += 9.500;
                        break;
                    case "hoop":
                        difficultyScore += 9.450;
                        realizationScore += 9.350;
                        break;
                    case "rope":
                        difficultyScore += 9.700;
                        realizationScore += 9.150;
                        break;
                }
            }

            double sumScores = difficultyScore + realizationScore;
            Console.WriteLine($"The team of {country} get {sumScores:f3} on {apparatus}.");

            double prcntgTill20 = ((score20 - sumScores) * 100) / score20;
            Console.WriteLine($"{prcntgTill20:f2}%");
        }
    }
}
