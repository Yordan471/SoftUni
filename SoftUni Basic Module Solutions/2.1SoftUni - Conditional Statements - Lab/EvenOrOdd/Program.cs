using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedInfo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());

            if (num <= 10)
            {
                Console.WriteLine("slow");
            }
            if (num > 10 && num <= 50)
            {
                Console.WriteLine("average");
            }
            if (num > 50 && num <= 150)
            {
                Console.WriteLine("fast");
            }
            if ( num > 150 && num <= 1000)
            {
                Console.WriteLine("ultra fast");
            }
            if (num > 1000)
            {
                Console.WriteLine("extremely fast");
            }
        }
    }
}
