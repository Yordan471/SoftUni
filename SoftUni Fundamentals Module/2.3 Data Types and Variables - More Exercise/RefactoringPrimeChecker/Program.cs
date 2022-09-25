using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactoringPrimeChecker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 2; i <= n; i++)
            {
                bool itsTrue = true;

                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        itsTrue = false;
                        break;
                    }
                }

                if (itsTrue)
                {
                    Console.WriteLine($"{i} -> true");
                }
                else
                {
                    Console.WriteLine($"{i} -> false");
                }
            }
        }
    }
}
