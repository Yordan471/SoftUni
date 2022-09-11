using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasterBakery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double priceFlourPerKg = double.Parse(Console.ReadLine());
            double kgFlour = double.Parse(Console.ReadLine());
            double kgSugar = double.Parse(Console.ReadLine());
            int numPackageEggs = int.Parse(Console.ReadLine());
            int packageYeast = int.Parse(Console.ReadLine());
            
            double priceForFlour = priceFlourPerKg * kgFlour;
            double priceKgSugar = kgSugar * (priceFlourPerKg * 0.75);
            double priceEggs = numPackageEggs * 1.0 * (priceFlourPerKg* 1.10);
            double pricePackageYeast = packageYeast * 1.0 * (priceFlourPerKg * 0.75 * 0.20);

            double sum = priceForFlour + priceKgSugar + priceEggs + pricePackageYeast;

            Console.WriteLine($"{sum:f2}");
        }
    }
}
