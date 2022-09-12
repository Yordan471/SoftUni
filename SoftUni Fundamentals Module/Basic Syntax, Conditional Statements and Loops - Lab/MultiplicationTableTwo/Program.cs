using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplicationTableTwo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int multiplyFrom = int.Parse(Console.ReadLine());

            int result = 0;

            if (multiplyFrom >= 10)
            {
                result = number * multiplyFrom;
                Console.WriteLine($"{number} X {multiplyFrom} = {result}");
                return;
            }

            for (int i = multiplyFrom; i <= 10; i++)
            {             
                    result = number * i;
                    Console.WriteLine($"{number} X {i} = {result}");
                    result = 0;              
            }
        }
    }
}
