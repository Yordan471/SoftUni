using System;

namespace weddingSeats
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char sector = char.Parse(Console.ReadLine());
            int numRowsFirstSector = int.Parse(Console.ReadLine());
            int numSeatsOddRow = int.Parse(Console.ReadLine());

            int numSeatsOddRow1 = numSeatsOddRow;
            int sectorCounter = 0;
            int counter = 0;

            for (int i = 'A'; i <= sector; i++)
            {
                for (int j = 1; j <= numRowsFirstSector + sectorCounter; j++)
                {
                    if (j % 2 == 0)
                    {
                        numSeatsOddRow1 += 2;
                    }
                    else
                    {
                        numSeatsOddRow1 = numSeatsOddRow;
                    }    

                    for (int k = (int)'a'; k < (int)'a' + numSeatsOddRow1; k++)
                    {
                        Console.WriteLine($"{(char)i}{j}{(char)k}");
                        counter++;
                    }
                }
               
                sectorCounter++;
            }
            Console.WriteLine(counter);
        }
    }
}
