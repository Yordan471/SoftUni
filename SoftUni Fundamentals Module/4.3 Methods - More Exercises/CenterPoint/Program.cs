using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CenterPoint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double firstX = double.Parse(Console.ReadLine());
            double firstY = double.Parse(Console.ReadLine()); 
            double secondX = double.Parse(Console.ReadLine());
            double secondY = double.Parse(Console.ReadLine());

            ClosestToZero(firstX, firstY, secondX, secondY);
        }

        static void ClosestToZero(double firstX, double firstY, double secondX, double secondY)
        {
            double firstNumber = 0;
            double secondNumber = 0;

            firstNumber = Math.Max(Math.Abs(firstX), Math.Abs(firstY));
            secondNumber = Math.Max(Math.Abs(secondX), Math.Abs(secondY));

            if (firstNumber >= secondNumber)
            {
                Console.WriteLine($"({secondX}, {secondY})");
            }
            else
            {
                Console.WriteLine($"({firstX}, {firstY})");
            }
        }
    }
}
