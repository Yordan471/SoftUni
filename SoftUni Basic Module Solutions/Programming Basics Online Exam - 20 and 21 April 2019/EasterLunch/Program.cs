using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasterLunch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numMeal = int.Parse(Console.ReadLine());
            int numEggs = int.Parse(Console.ReadLine());
            int kgCoockies = int.Parse(Console.ReadLine());

            double meal = 3.20;
            double eggs = 4.35;  // for 12 eggs
            double coockies = 5.40;  // per kg
            double dyeForEggs = 0.15;

            double sumMeals = numMeal * meal;
            double sumEggs = numEggs * eggs;
            double allSeparateEggs = numEggs * 12;
            double sumCoockies = kgCoockies * coockies;
            double sumDyeForEggs = allSeparateEggs * dyeForEggs;

            double sumResult = sumMeals + sumEggs + sumCoockies + sumDyeForEggs;

            Console.WriteLine($"{sumResult:f2}");
                
        }
    }
}
