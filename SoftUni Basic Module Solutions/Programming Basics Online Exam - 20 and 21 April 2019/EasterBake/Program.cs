using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasterBake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberEasterCakes = int.Parse(Console.ReadLine());

            int packageSugar = 950;
            int packageFlour = 750;
            int maxValueFlour = -100000;
            int maxValueSugar = -100000;
            int counter = 0;
            int sumFlour = 0;
            int sumSugar = 0;

            for (int i = 1; i <= numberEasterCakes; i++)
            {
                int sugarValue = int.Parse(Console.ReadLine());
                int flourValue = int.Parse(Console.ReadLine());

                sumSugar += sugarValue;
                sumFlour += flourValue;

                counter++;

                if (maxValueFlour < flourValue)
                {
                    maxValueFlour = flourValue;
                }


                if (maxValueSugar < sugarValue)
                {
                    maxValueSugar = sugarValue;
                }
            }

            double numberOfPackagesFlour = Math.Ceiling(sumFlour * 1.0 / packageFlour);
            double numberOfPackagesSugar = Math.Ceiling(sumSugar * 1.0 / packageSugar);

            Console.WriteLine($"Sugar: {numberOfPackagesSugar}");
            Console.WriteLine($"Flour: {numberOfPackagesFlour}");
            Console.WriteLine($"Max used flour is {maxValueFlour} grams, max used sugar is {maxValueSugar} grams.");

        }
    }
}
