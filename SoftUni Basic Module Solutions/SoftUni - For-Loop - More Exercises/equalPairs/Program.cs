using System;

namespace equalPairs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int summOdd = 0;
            int sumEven = 0;
            int diff = 0;
            bool areTheSumsEaual = true;

            for (int i = 1; i <= n; i++)
            {
                int numberOne = int.Parse(Console.ReadLine());
                int numberTwo = int.Parse(Console.ReadLine());
                
                if (i % 2 == 0)
                {
                    sumEven = numberOne + numberTwo;
                }
                else
                {
                    summOdd = numberOne + numberTwo;
                }

                if (i > 1 && Math.Abs(sumEven - summOdd) > diff)
                {
                    diff = Math.Abs(sumEven - summOdd); ;
                    areTheSumsEaual = false;
                }
            }

            if (areTheSumsEaual == true)
            {
                Console.WriteLine($"Yes, value={summOdd}");
            }
            else
            {
                Console.WriteLine($"No, maxdiff={diff}");
            }
        }
    }
}
