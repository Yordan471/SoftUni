using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertMetersToKilometers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            float metersToKilometers = (float)number / 1000;

            Console.WriteLine($"{metersToKilometers:f2}");
        }
    }
}
