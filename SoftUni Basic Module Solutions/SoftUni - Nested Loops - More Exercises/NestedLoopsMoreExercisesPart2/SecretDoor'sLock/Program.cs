using System;

namespace SecretDoor_sLock
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int highestHundred = int.Parse(Console.ReadLine());
            int highestTen = int.Parse(Console.ReadLine());
            int highestOne = int.Parse(Console.ReadLine());

            bool even = false;
            bool simple = false;

            for (int i = 2; i <= highestHundred; i++)
            {
                for (int j = 2; j <= highestTen; j++)
                {
                    for (int k = 2; k <= highestOne; k++)
                    {
                        if (i % 2 == 0 && k % 2 == 0)
                        {
                            even = true;
                        }

                        if (j == 2 || j == 3 || j == 5 || j == 7)
                        {
                            simple = true;
                        }

                        if (even && simple)
                        {
                            Console.WriteLine($"{i} {j} {k}");
                          
                        }

                        even = false;
                        simple = false;
                    }
                }
            }
        }
    }
}
