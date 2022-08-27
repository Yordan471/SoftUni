using System;

namespace Profit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOneLv = int.Parse(Console.ReadLine());
            int numTwoLv = int.Parse(Console.ReadLine());
            int numFiveLv = int.Parse(Console.ReadLine());
            int sum = int.Parse(Console.ReadLine());
            int sumMoney = 0;

            for (int i = 0; i <= numOneLv; i++)
            {
                for (int j = 0; j <= numTwoLv; j++)
                {
                    for (int k = 0; k <= numFiveLv; k++)
                    {
                        sumMoney = i * 1 + j * 2 + k * 5;

                        if (sumMoney == sum)
                        {
                            Console.WriteLine($"{i} * 1 lv. + {j} * 2 lv. + {k} * 5 lv. = {sum} lv.");
                        }
                    }
                }
            }
        }
    }
}
