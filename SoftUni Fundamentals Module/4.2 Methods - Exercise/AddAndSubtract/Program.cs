using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddAndSubtract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            Console.WriteLine(SubtractThirdnumberFromSum(firstNumber, secondNumber, thirdNumber));

        }

        static int GetSumOfFirstTwoNumbers(int firstNumber, int secondNumber)
        {
            return firstNumber + secondNumber;

           
        }

        static int SubtractThirdnumberFromSum(int firstNumber, int secondNumber, int thirdNumber)
        {
            return GetSumOfFirstTwoNumbers(firstNumber, secondNumber) - thirdNumber;         
        }
    }
}
