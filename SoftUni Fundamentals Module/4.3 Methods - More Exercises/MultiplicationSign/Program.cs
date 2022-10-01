using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplicationSign
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            CheckIfResultIsPositiveOrNegative(num1, num2, num3);
        }

        static void CheckIfResultIsPositiveOrNegative(int num1,
            int num2, int num3)
        {
            bool twoNegatives = false;

            if ((num1 < 0 && num2 < 0) || (num1 < 0 && num3 < 0) ||
                num2 < 0 && num3 < 0)
            {
                twoNegatives = true;

                if ((num1 == 0 || num2 == 0 || num3 == 0) ||
                    (num1 < 0 && num2 < 0 && num3 < 0))
                {
                    twoNegatives = false;
                }

            }

            if ((num1 > 0 && num2 > 0 && num3 > 0) || twoNegatives)
            {
                Console.WriteLine("positive");
            }
            else if (num1 == 0 || num2 == 0 || num3 == 0)
            {
                Console.WriteLine("zero");
            }
            else
            {
                Console.WriteLine("negative");
            }
        }
    }
}
