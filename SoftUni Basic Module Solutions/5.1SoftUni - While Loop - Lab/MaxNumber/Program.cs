using System;

namespace MaxNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string comandNums = Console.ReadLine();
            int maxNum = -1000000;

            while (comandNums != "Stop")
            {
                int numbers = int.Parse(comandNums);

                if (maxNum < numbers)
                {
                    maxNum = numbers;
                }
                comandNums = Console.ReadLine();
            }

            Console.WriteLine(maxNum);
        }
    }
}
