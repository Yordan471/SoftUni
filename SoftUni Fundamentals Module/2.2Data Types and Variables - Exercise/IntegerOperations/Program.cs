using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegerOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());
            int fourthNum = int.Parse(Console.ReadLine());

            int sumFirstAndSecond = firstNum + secondNum;
            int divideByThirdNum = sumFirstAndSecond / thirdNum;
            int multyplieByFourthNum = divideByThirdNum * fourthNum;

            int result = multyplieByFourthNum;

            Console.WriteLine(result);
        }
    }
}
