using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorialDevision
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            double result = FactorialDivide(firstNumber, secondNumber);
            Console.WriteLine($"{result:f2}"); 
        }

        static double FactorialFirstNumber(int firstNumber)
        {
            double factorialFirstNumber = 1;

            for (int i = 2; i <= firstNumber; i++)
            {
                factorialFirstNumber *= i;
            }

            return factorialFirstNumber;
        }

        static double FactorialSecondNumber(int secondNumber)
        {
            double factorialSecondNumber = 1;

            for (int i = 2; i <= secondNumber; i++)
            {
                factorialSecondNumber *= i;
            }

            return factorialSecondNumber;
        }

        static double FactorialDivide(int firstNumber, int secondNumber)
        {
            return FactorialFirstNumber(firstNumber) / FactorialSecondNumber(secondNumber);
        }
    }
}
