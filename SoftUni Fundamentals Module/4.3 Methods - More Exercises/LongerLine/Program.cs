using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongerLine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double firstX1 = double.Parse(Console.ReadLine());
            double firstY1 = double.Parse(Console.ReadLine());
            double secondX2 = double.Parse(Console.ReadLine());
            double secondY2 = double.Parse(Console.ReadLine());
            double thirdX3 = double.Parse(Console.ReadLine());
            double thirdY3 = double.Parse(Console.ReadLine());
            double fourthX4 = double.Parse(Console.ReadLine());
            double fourthY4 = double.Parse(Console.ReadLine());

            LengthOfLines(firstX1, firstY1, secondX2, secondY2,
                thirdX3, thirdY3, fourthX4, fourthY4);
        }

        static void CheckWichPointIsCloserToZero(double a, double b, double c, double d)
            
        {
            double firstResult = a * a + b * b;
            double secondResult = c * c + d * d;

            if (firstResult <= secondResult)
            {
                Console.WriteLine($"({a}, {b})({c}, {d})");
            }
            else
            {
                Console.WriteLine($"({c}, {d})({a}, {b})");
            }
        }

        static void LengthOfLines(double a1, double b1, 
            double a2, double b2, double a3, double b3,
            double a4, double b4)
        {
            double LengthFirstLine = Math.Pow(a1 - a2, 2) +
                Math.Pow(b1 - b2, 2);
            double LengthSecondLine = Math.Pow(a3 - a4, 2) +
                Math.Pow(b3 - b4, 2);

            if (LengthFirstLine >= LengthSecondLine)
            {
                CheckWichPointIsCloserToZero(a1, b1, a2, b2);
            }
            else
            {
                CheckWichPointIsCloserToZero(a3, b3, a4, b4);
            }
        }
    }
}
