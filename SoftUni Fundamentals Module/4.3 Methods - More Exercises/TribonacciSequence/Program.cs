using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TribonacciSequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            TribonacciSequence(num);
        }

        static void TribonacciSequence (int num)
        {
            int thirdNum = 1;
            int secondNum = 0;
            int firstNum = 0;
            int sumForNextNum = 0;

            if (num == 1)
            {
                Console.WriteLine(1);
            }
            else if (num == 2)
            {
                Console.WriteLine(1 + " " + 1);
            }
            else if (num >= 3)
            {
                for (int i = 1; i <= num; i++)
                {
                    sumForNextNum = firstNum + secondNum + thirdNum;

                    Console.Write($"{sumForNextNum} ");

                    if (i >= 2)
                    {
                        firstNum = secondNum;
                        secondNum = thirdNum;
                        thirdNum = sumForNextNum;
                    }               
                }
            }
        }
    }
}
