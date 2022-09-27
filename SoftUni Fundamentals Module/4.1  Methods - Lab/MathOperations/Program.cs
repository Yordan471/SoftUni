using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            string operation = Console.ReadLine();
            int secondNumber = int.Parse(Console.ReadLine());

            Console.WriteLine(Calculations(firstNumber, operation, secondNumber));
        }

        static int Calculations(int firstNumber, string operation, int secondNumber)
        {
            int result = 0;

            switch (operation)
            {
                case "/":
                    result = firstNumber / secondNumber;
                    break;
                case "*":
                    result = firstNumber * secondNumber;
                    break;
                case "+":
                    result = firstNumber + secondNumber; 
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;
            }

            return result;
        }

  //   static int Divide(int firstNumber, int secondNumber)
  //   {
  //       return firstNumber / secondNumber;
  //   }
  //
  //   static int Multiply(int firstNumber, int secondNumber)
  //   {
  //       return firstNumber * secondNumber;
  //   }
  //
  //   static int Add(int firstNumber, int secondNumber)
  //   {
  //       return firstNumber + secondNumber;
  //   }
  //
  //   static int Subtraction(int firstNumber, int secondNumber)
  //   {
  //       return firstNumber - secondNumber;
  //   }
    }
}
