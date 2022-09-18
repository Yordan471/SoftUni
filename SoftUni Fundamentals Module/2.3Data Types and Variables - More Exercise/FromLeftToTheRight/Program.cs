using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FromLeftToTheRight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            long firstNumber = 0;
            long secondNumber = 0;
            string sFirstNumber = string.Empty;
            string sSecondNumber = string.Empty;
            long saveSumSecondNumber = 0;
            long saveSumFirstNumber = 0;
            bool isOut = true;

            for (int i = 1; i <= n; i++)
            {
                string numbers = Console.ReadLine();

                for (int j = 0; j < numbers.Length; j++)
                {
                    if (numbers[j] == 32)
                    {
                        for (int k = j + 1; k < numbers.Length; k++)
                        {
                            sSecondNumber += numbers[k];
                            isOut = false;
                        }
                    }

                    if (isOut)
                    {
                        sFirstNumber += numbers[0 + j];
                    }
                }
            
                firstNumber = long.Parse(sFirstNumber);
                secondNumber = long.Parse(sSecondNumber);

                if (firstNumber > secondNumber)
                {

                    while (firstNumber != 0)
                    {
                        saveSumFirstNumber += firstNumber % 10;
                        firstNumber /= 10;
                    }

                    Console.WriteLine($"{Math.Abs(saveSumFirstNumber)}");
                }
                else
                {

                    while (secondNumber != 0)
                    {
                        saveSumSecondNumber += secondNumber % 10;
                        secondNumber /= 10;
                    }

                    Console.WriteLine($"{Math.Abs(saveSumSecondNumber)}");
                }

                saveSumSecondNumber = 0;
                saveSumFirstNumber = 0;
                sFirstNumber = string.Empty;
                sSecondNumber = string.Empty;
                isOut = true;
            }
        }
    }
}
