using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathOperations
{
    public class MathOperations
    {
        public int Add(int firstNum, int secondNum)
        {
            return firstNum + secondNum;
        }

        public double Add(double firstNum, double secondNum, double thirdNum)
        {
            return firstNum + secondNum * thirdNum;
        }

        public decimal Add(decimal firstNum, decimal secondNum, decimal thirdNum)
        {
            return firstNum + secondNum + thirdNum;
        }
    }
}
