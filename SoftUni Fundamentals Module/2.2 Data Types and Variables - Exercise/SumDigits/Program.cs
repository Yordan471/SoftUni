using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumDigits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sNumber = Console.ReadLine();
            int number = int.Parse(sNumber);

            int digit = 0;

            for (int i = 1; i <= sNumber.Length; i++)
            {
                digit += number % 10;
                number /= 10;
            }

            Console.WriteLine(digit);
        }
    }
}
