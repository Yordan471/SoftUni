using System;

namespace luckyNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int firstTwoNums = 0;
            int secondTwoNums = 0;

            for (int i = 1; i <= 9; i++)
            {
                for (int j = 1; j <= 9; j++)
                {
                    for (int k = 1; k <= 9; k++)
                    {
                        for (int l = 1; l <= 9; l++)
                        {
                            firstTwoNums = i + j;
                            secondTwoNums = k + l;

                            if (firstTwoNums != secondTwoNums || n % firstTwoNums != 0)
                            {
                                continue;
                            }
                            else
                            {
                                Console.Write($"{i}{j}{k}{l} ");
                            }
                        }
                    }
                }
            }
        }
    }
}
