using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TopNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();

            if (CheckIfThereIsOddDigitInNumber(number) == true &&
                SumOfNumberDigits(number) == true)
            {
                Console.WriteLine(number);
            }
        }

        static bool SumOfNumberDigits(string number)
        {
            int intNumber = int.Parse(number);
            int digit = 0;
            int sumNumber = 0;

            for (int i = 17; i <= intNumber; i++)
            {
                digit = i;

                for (int j = 0; j < number.Length; j++)
                {
                    sumNumber += digit % 2;
                    digit = digit / 10;
                }

                if
            }


            
        }

        static bool CheckIfThereIsOddDigitInNumber(string number)
        {
            int[] array = number
            .Split()
            .Select(int.Parse)
            .ToArray();

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0)
                {
                    return true;                   
                }
            }

            return false;
        }
    }
}
