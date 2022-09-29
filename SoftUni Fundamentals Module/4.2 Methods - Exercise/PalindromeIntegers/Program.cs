using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalindromeIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string number = Console.ReadLine();

                int counter = 0;

                for (int i = 0; i < number.Length; i++)
                {
                    counter++;
                }

                if (counter % 2 == 0)
                {
                    CheckIfEvenNumberIsPalindome(number);
                    break;
                }
                else if (counter % 2 != 0)
                {
                    CheckIfOddNumberIsPalindrome(number);
                    break;
                }
                else
                {
                    OneDigitNumberIsPalindrome(number);
                    break;
                }
            }
        }

        static void CheckIfEvenNumberIsPalindome(string number)
        {
            string rightNums = String.Empty;
            string leftNums = String.Empty;
            int digit = 1;

            {
                for (int i = 0; i < number.Length; i++)
                {

                    if (i < number.Length / 2)
                    {
                        leftNums += number[i];
                    }
                    else if (i >= number.Length / 2)
                    {
                        rightNums += number[number.Length - digit];
                        digit += 1;
                    }
                }
            }



            if (leftNums == rightNums)
            {
                Console.WriteLine(true);
            }
            else
            {
                Console.WriteLine(false);
            }
        }

        static void CheckIfOddNumberIsPalindrome(string number)
        {
            string leftNums = String.Empty;
            string rightNums = String.Empty;
            int digit = 1;

            for (int i = 0; i < number.Length; i++)
            {
                if (i < (number.Length / 2))
                {
                    leftNums += number[i];
                }
                else if (i > number.Length / 2)
                {
                    rightNums += number[number.Length - digit];
                    digit++;
                }
            }

            if (rightNums == leftNums)
            {
                Console.WriteLine(true);
            }
            else
            {
                Console.WriteLine(false);
            }
        }

        static void OneDigitNumberIsPalindrome(string number)
        {
            Console.WriteLine(true);
        }
    }
}
