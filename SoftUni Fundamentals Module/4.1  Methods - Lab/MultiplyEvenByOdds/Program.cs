using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplyEvenByOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            
            number = Math.Abs(number);

            int sumOddDigits = GetSumOfOddDigits(number);
            int sumEvenDigits = GetSumOfEvenDigits(number);
            int result = GetMultipleOfEvenAndOdd(sumEvenDigits, sumOddDigits);

            Console.WriteLine(result);      
        }

        static int GetSumOfEvenDigits(int number)
        {
            int digit = 0;
            int sumEvenDigits = 0;

            while (number > 0)
            {
                digit = number % 10; 

                if (digit % 2 == 0)
                {
                    sumEvenDigits += digit;
                }

                number /= 10;
            }

            return sumEvenDigits;
        }

        static int GetSumOfOddDigits(int number)
        {
            int digit = 0;
            int sumOddDigits = 0;

            while (number > 0)
            {
                digit = number % 10;

                if (digit % 2 != 0)
                {
                    sumOddDigits += digit;
                }

                number /= 10;
            }

            return sumOddDigits;
        }

        static int GetMultipleOfEvenAndOdd(int sumEvenDigits, int sumOddDigits)
        {
            return sumEvenDigits * sumOddDigits;
        }
    }
}
