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
            int firstX = int.Parse(Console.ReadLine());
            int firstY = int.Parse(Console.ReadLine()); 
            int secondX = int.Parse(Console.ReadLine());
            int secondY = int.Parse(Console.ReadLine());

            ClosestToZero(firstX, firstY, secondX, secondY);
        }

        static void ClosestToZero(int firstX, int firstY, int secondX, int secondY)
        {
            int firstNumber = 0;
            int secondNumber = 0;

            firstNumber = Math.Max(Math.Abs(firstX), Math.Abs(firstY));
            secondNumber = Math.Max(Math.Abs(secondX), Math.Abs(secondY));

            if (firstNumber > secondNumber)
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
