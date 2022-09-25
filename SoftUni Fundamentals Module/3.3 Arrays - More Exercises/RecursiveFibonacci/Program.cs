using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursiveFibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int[] fibonachiArray = new int[50];

            fibonachiArray[0] = 1;
            fibonachiArray[1] = 1;

            if (number > 2)
            {
                for (int i = 2; i < number; i++)
                {
                    fibonachiArray[i] = fibonachiArray[i - 1] + fibonachiArray[i - 2];
                }
            }

            Console.WriteLine(fibonachiArray[number - 1]);
        }
    }
}
