using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace PrintingTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            PrintWholeTriangle(number);
        }

        static void PrintLine(int start, int end)
        {
           for (int i = start; i <= end; i++)
            {
                Console.Write(i + " ");
            }

           Console.WriteLine();
        }

        static void PrintWholeTriangle(int number)
        {
            for (int i = 1; i <= number; i++)
            {
                PrintLine(1, i);
            }

            for (int i = number - 1; i >= 1; i--)
            {
                PrintLine(1, i);
            }    
        }
    }
}
