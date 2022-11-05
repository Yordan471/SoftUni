using System;
using System.Collections.Generic;

namespace MultiplyBigNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string bigNumber = Console.ReadLine();
            int smallNumber = int.Parse(Console.ReadLine());

            bigNumber = bigNumber.TrimStart(new char[] { '0' });
            char[] bigNumberToChar = bigNumber.ToCharArray();

            if (smallNumber == 0)
            {
                Console.WriteLine(0);
                return;
            }

            List<string> addNums = new List<string>();
            int parseNumber = 0;

            for (int i = bigNumber.Length - 1; i >= 0; i--)
            {
                parseNumber = (int.Parse(Convert.ToString(bigNumber[i])) * smallNumber) + parseNumber;
                addNums.Insert(0, (parseNumber % 10).ToString());
                parseNumber /= 10;
            }

            if (parseNumber > 0)
            {
                Console.WriteLine($"{parseNumber}{string.Join("", addNums)}"); ;
            }
            else
            {
                Console.WriteLine($"{string.Join("", addNums)}");
            }
        }
    }
}
