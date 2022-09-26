using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathPower
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double baseNumber = double.Parse(Console.ReadLine());
            double power = double.Parse(Console.ReadLine());

            double result = BaseNumberRaisedToPower(baseNumber, power);

            Console.WriteLine(result);
        }

        static double BaseNumberRaisedToPower(double baseNumber, double power)
        {
            return Math.Pow(baseNumber, power);
        }
    }
}
