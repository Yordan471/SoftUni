using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateRectangleArea
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int height = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());

            double area =  CalculateAreaOfARectangle(height, width);
            Console.WriteLine(area);
        }

        static double CalculateAreaOfARectangle(int height, int width)
        {
            return height * width;
        }
    }
}
