using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevisionWithoutReminder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int p1 = 0;
            int p2 = 0;
            int p3 = 0;

            for (int i = 1; i <= n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (number % 2 == 0)
                {
                    p1++;
                }

                if (number % 3 == 0)
                {
                    p2++;
                }

                if (number % 4 == 0)
                {
                    p3++;
                }
            }

            double prcntgP1 = (p1 * 100 * 1.0) / n;
            double prcntgP2 = (p2 * 100 * 1.0) / n;
            double prcntgP3 = (p3 * 100 * 1.0) / n;

            Console.WriteLine($"{prcntgP1:f2}%");
            Console.WriteLine($"{prcntgP2:f2}%");
            Console.WriteLine($"{prcntgP3:f2}%");

        }
    }
}
