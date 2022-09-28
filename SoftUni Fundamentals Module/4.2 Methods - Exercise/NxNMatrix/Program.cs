using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NxNMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            PrintNxNMatrix(number);

        }

        static void PrintNxNMatrix(int number)
        {
            int counter = 0;

            while (counter != number)
            {
                counter++;

                for (int i = 1; i <= number; i++)
                {
                    Console.Write(number + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
