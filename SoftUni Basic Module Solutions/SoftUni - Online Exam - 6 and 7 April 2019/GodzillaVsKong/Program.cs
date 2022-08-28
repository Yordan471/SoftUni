using System;

namespace GodzillaVsKong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double movieBudget = double.Parse(Console.ReadLine());
            int numExtras = int.Parse(Console.ReadLine());
            double suitePrice = double.Parse(Console.ReadLine());

            double decor = movieBudget * 0.10;
            double sumExtrasSum = numExtras * suitePrice;

            if (numExtras > 150)
            {
                sumExtrasSum -= sumExtrasSum * 0.10;
            }

            double overallSum = decor + sumExtrasSum;
            if (overallSum > movieBudget)
            {
                Console.WriteLine($"Not enough money!");
                Console.WriteLine($"Wingard needs {Math.Abs(movieBudget - overallSum):f2} leva more.");
            }
            else if (overallSum <= movieBudget)
            {
                Console.WriteLine($"Action!");
                Console.WriteLine($"Wingard starts filming with {Math.Abs(overallSum - movieBudget):f2} leva left.");
            }
        }
    }
}
