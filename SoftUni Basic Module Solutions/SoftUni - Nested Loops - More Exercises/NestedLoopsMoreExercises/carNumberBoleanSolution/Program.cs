using System;
using System.Globalization;

namespace carNumberBoleanSolution
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            for (int n1 = num1; n1 <= num2; n1++)
            {
                for (int n2 = num1; n2 <= num2; n2++)
                {
                    for (int n3 = num1; n3 <= num2; n3++)
                    {
                        for (int n4 = num1; n4 <= num2; n4++)
                        {
                            bool isEvenN1 = n1 % 2 == 0;
                            bool isEvenN4 = n4 % 2 == 0;
                            bool isOddN1 = n1 % 2 != 0;
                            bool isOddN4 = n4 % 2 != 0;
                            bool isSumN2N3 = (n2 + n3) % 2 == 0;
                            bool isFirstBigger = n1 > n4;

                            if ((isEvenN1 && isOddN4) || (isOddN1 && isEvenN4))
                            {
                                if (isSumN2N3 && isFirstBigger)
                                {
                                    Console.Write($"{n1}{n2}{n3}{n4} ");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
