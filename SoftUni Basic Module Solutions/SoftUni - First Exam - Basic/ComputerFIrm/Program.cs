using System;

namespace ComputerFIrm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Търсим среден рейтинг и направените продажби.
            //Средния рейтинг е последната въведена цифра.

            int numComputers = int.Parse(Console.ReadLine());

            double averageRaiting = 0;
            double possibleSells = 0;
            double sells = 0;

            for (int i = 1; i <= numComputers; i++)
            {
                int possibleSellsAndRaiting = int.Parse(Console.ReadLine());

                int raiting = possibleSellsAndRaiting % 10;
                possibleSells = possibleSellsAndRaiting / 10;
                
                switch (raiting)
                {
                    case 2:
                        possibleSells *= 0; 
                        sells += possibleSells; break;
                    case 3:
                        possibleSells *= 0.5; 
                        sells += possibleSells; break;
                    case 4:
                        possibleSells *= 0.7;
                        sells += possibleSells; break;
                    case 5:
                        possibleSells *= 0.85;
                        sells += possibleSells; break;
                    case 6:
                        possibleSells *= 1;
                        sells += possibleSells; break;
                }
                averageRaiting += raiting;                                               
            }
            averageRaiting = averageRaiting / numComputers;

            Console.WriteLine($"{sells:f2}");
            Console.WriteLine($"{averageRaiting:f2}");
        }
    }
}
