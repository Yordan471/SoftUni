using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiceMustFLow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //We need to calculate the total amount that can be extracted from a source
            //The source has starting yield indicating how much we can mine for 1 day
            //After 1 day we can mine with 10 less, the second day
            //Source is profitable if yield is at least 100, else abondon source.
            //Mining crew consumes 26 spices at the end of the shift ones and 26 more when the mine is exhausted.
            //The crew cannot eat more then there is in storage.
            //Print how many days the mine has operated and the total amount extracted.

            int startingYield = int.Parse(Console.ReadLine());

            int minedSpice = 0;
            int counter = 0;
            int less10 = 0;

            if (startingYield < 100)
            {
                Console.WriteLine(counter);
                Console.WriteLine(minedSpice);
                return;
            }

            while (true)
            {
                counter++;

                if(counter == 2)
                {
                    less10 = 10;
                }

                startingYield -= less10;

                if (startingYield < 100)
                {
                    counter--;
                    minedSpice -= 26;
                    break;
                }

                minedSpice += startingYield;
                minedSpice -= 26;

                if (minedSpice < 0)
                {
                    break;
                }
            }

            Console.WriteLine(counter);
            Console.WriteLine(minedSpice);
        }
    }
}
