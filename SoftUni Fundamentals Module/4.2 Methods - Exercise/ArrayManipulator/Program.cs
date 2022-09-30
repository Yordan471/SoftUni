using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            CheckForTopNumber(number);
        }

        static bool CheckIfDivisibleBy8(int number)
        {
            int sumDigits = 0;

            while (number > 0)
            {
                sumDigits += number % 10;
                number /= 10;
            }

            if (sumDigits % 8 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool CheckForAtleastOneOddDigit(int number)
        {
            int digit = 0;

            while (number > 0)
            {
                digit += number % 10;
                number = number / 10;

                if (digit % 2 != 0)
                {
                    return true;
                }
            }

            return false;
        }

        static void CheckForTopNumber(int number)
        {
            for (int i = 1; i <= number; i++)
            {
                if (CheckForAtleastOneOddDigit(i) == true && CheckIfDivisibleBy8(i) == true)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
