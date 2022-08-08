using System;

namespace Histogram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            double p1 = 0; double p2 = 0; double p3 = 0;
            double p4 = 0; double p5 = 0;

            int numbersP1 = 0; int numbersP2 = 0;
            int numbersP3 = 0; int numbersP4 = 0;
            int numbersP5 = 0;

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (num < 200)
                {
                    numbersP1++;
                }
                else if (num >= 200 && num <= 399)
                {
                    numbersP2++;
                }
                else if (num >= 400 && num <= 599)
                {
                    numbersP3++;
                }
                else if (num >= 600 && num <= 799)
                {
                    numbersP4++;
                }
                else
                {
                    numbersP5++;
                }               
            }
            p1 = numbersP1 * 100.0 / n;
            p2 = numbersP2 * 100.0 / n;
            p3 = numbersP3 * 100.0 / n;
            p4 = numbersP4 * 100.0 / n;
            p5 = numbersP5 * 100.0 / n;

            Console.WriteLine($"{p1:f2}%");
            Console.WriteLine($"{p2:f2}%");
            Console.WriteLine($"{p3:f2}%");
            Console.WriteLine($"{p4:f2}%");
            Console.WriteLine($"{p5:f2}%");
        }
    }
}
