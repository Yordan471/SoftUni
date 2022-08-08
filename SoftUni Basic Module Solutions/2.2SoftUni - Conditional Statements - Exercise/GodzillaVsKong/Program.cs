using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GodzillaVsKong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("");
            double Budget = double.Parse(Console.ReadLine());

            Console.Write("");
            int brStatisti = int.Parse(Console.ReadLine());

            Console.Write("");
            double clothPrice = double.Parse(Console.ReadLine());
            
            double fullClothPrice = clothPrice * brStatisti;
            double decorPrice = Budget * 0.1;
           
           

            if (brStatisti > 150)
            {
                fullClothPrice = fullClothPrice - (fullClothPrice * 0.1);
            }
            double fullPrice = fullClothPrice + decorPrice;

            if (fullPrice > Budget)
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {fullPrice - Budget:f2} leva more. ");
            }
            else if (Budget >= fullPrice)
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {Budget - fullPrice:f2} leva left.");
            }
        }
    }
}
