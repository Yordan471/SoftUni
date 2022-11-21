using System;
using System.Numerics;

namespace Convert_from_base_10_to_base_N
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputInfo = Console.ReadLine()
                .Split();

            int numberBase = int.Parse(inputInfo[0]);
            BigInteger numberBaseTen = BigInteger.Parse(inputInfo[1]);
            string numberToString = string.Empty;

            while (numberBaseTen > 0)
            {
                BigInteger remainder = numberBaseTen % numberBase;
                numberToString = remainder + numberToString;
                numberBaseTen /= numberBase;
            }

            Console.WriteLine(numberToString);

        }
    }
}
