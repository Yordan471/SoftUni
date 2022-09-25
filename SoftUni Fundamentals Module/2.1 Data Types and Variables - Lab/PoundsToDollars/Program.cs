using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoundsToDollars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal pound = decimal.Parse(Console.ReadLine());

            decimal onePoundToDollar = 1.31M;

            decimal sum = pound * onePoundToDollar;

            Console.WriteLine($"{sum:f3}");
        }
    }
}
