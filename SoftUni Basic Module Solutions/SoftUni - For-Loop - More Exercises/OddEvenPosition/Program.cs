using System;

namespace OddEvenPosition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int maxOdd = -1000000;
            int minOdd = 100000;
            double oddSum = 0.00;

            int maxEven = -100000;
            int minEven = 100000;
            double evenSum = 0.00;
            bool nIsANull = false;
            bool nIsAOne = false;

            if (n == 0)
            {
                nIsANull = true;
            }

            for (int i = 1; i <= n; i++)
            {
                int number = int.Parse(Console.ReadLine());

       //   if (n == 0)
       //   {
       //       nIsANull = true;
       //       break;
       //   }

                if (i % 2 != 0)
                {
                    oddSum += number;
                    if (maxOdd < number)
                    {
                        maxOdd = number;
                    }

                    if (minOdd > number)
                    {
                        minOdd = number;
                    }
                }

                if (n == 1)
                {
                    nIsAOne = true;
                    break;
                }

                if (i % 2 == 0)
                {
                    evenSum += number;
                    if (maxEven < number)
                    {
                        maxEven = number;
                    }

                    if (minEven > number)
                    {
                        minEven = number;
                    }
                }                 
            }

            if (nIsANull)
            {
                Console.WriteLine($"OddSum={oddSum:f2},");
                Console.WriteLine($"OddMin=No,");
                Console.WriteLine($"OddMax=No,");
                Console.WriteLine($"EvenSum={evenSum:f2},");
                Console.WriteLine($"EvenMin=No,");
                Console.WriteLine($"EvenMax=No,");
            }

            else if (nIsAOne)
            {
                Console.WriteLine($"OddSum={oddSum:f2},");
                Console.WriteLine($"OddMin={minOdd:f2},");
                Console.WriteLine($"OddMax={maxOdd:f2},");
                Console.WriteLine($"EvenSum={evenSum:f2},");
                Console.WriteLine($"EvenMin=No,");
                Console.WriteLine($"EvenMax=No,");
            }

            else
            {
                Console.WriteLine($"OddSum={oddSum:f2},");
                Console.WriteLine($"OddMin={minOdd:f2},");
                Console.WriteLine($"OddMax={maxOdd:f2},");
                Console.WriteLine($"EvenSum={evenSum:f2},");
                Console.WriteLine($"EvenMin={minEven:f2},");
                Console.WriteLine($"EvenMax={maxEven:f2},");
            }
        }
    }
}
