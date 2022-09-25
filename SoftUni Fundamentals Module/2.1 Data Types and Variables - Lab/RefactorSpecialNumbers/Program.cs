using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorSpecialNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int remainder = 0;

            for (int i = 1; i <= n; i++)
            {
               int saveI = i;

                while (i > 0)
                {
                    remainder += i % 10;
                    i = i / 10;
                }

                bool itsTrue = (remainder == 5) || (remainder == 7) || (remainder == 11);
                Console.WriteLine("{0} -> {1}", saveI, itsTrue);

                remainder = 0;
                i = saveI;
            }

        }
    }
}
