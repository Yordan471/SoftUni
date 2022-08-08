using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    public class Program
    {
        static void Main(string[] args)
        {
            double Premiere = 12;
            double Normal = 7.50;
            double Discount = 5;

            string type = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine()) ;
            int columns = int.Parse(Console.ReadLine()) ;

            double income = 0.0;

            if (type == "Premiere")
            {
                income += rows * columns * Premiere;
            }
            else if (type == "Normal")
            {
                income = rows * columns * Normal;
            }
            else if (type == "Discount")
            {
                income = rows * columns * Discount;
            }
            Console.WriteLine($"{income:f2} leva");
        }
    }
}
