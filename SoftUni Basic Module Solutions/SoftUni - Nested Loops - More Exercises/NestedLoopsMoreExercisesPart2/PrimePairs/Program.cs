using System;

namespace PrimePairs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int begginingValueFirstPair = int.Parse(Console.ReadLine());
            int begginingValueSecondPair = int.Parse(Console.ReadLine());
            int diffValueFirstPair = int.Parse(Console.ReadLine());
            int diffValueSecondPair = int.Parse(Console.ReadLine());

            int endValueFirstPair = begginingValueFirstPair + diffValueFirstPair;
            int endValueSecondPair = begginingValueSecondPair + diffValueSecondPair;

            int firstPair = 0;
            int secondPair = 0;

            int counterFirstPair = 0;
            int counterSecondPair = 0;

            for (int i = begginingValueFirstPair; i <= endValueFirstPair; i++)
            {


                for (int j = begginingValueSecondPair; j <= endValueSecondPair; j++)
                {
                   for (int k = 1; k <= i; k++)
                   {
                        firstPair = i % k;

                        if (firstPair == 0)
                        {
                            counterFirstPair++;
                        }                                                
                   }

                   if (counterFirstPair == 2)
                   {
                        for (int l = 2; l <= j; l++)
                        {
                            secondPair = i % l;

                            if (secondPair == 0)
                            {
                                counterSecondPair++;
                            }
                        }

                        if (counterSecondPair == 2)
                        {
                            Console.WriteLine($"{i}{j}");
                        }
                    }                                           
                }
            }
        }
    }
}
