using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("");
            double budget = double.Parse(Console.ReadLine());

            Console.Write("");
            int N = int.Parse(Console.ReadLine());

            Console.Write("");
            int M = int.Parse(Console.ReadLine());

            Console.Write("");
            int P = int.Parse(Console.ReadLine());

            double videoKarta = 250;

            double videokarti = videoKarta * N;
            double procesori = M * (videokarti * 0.35);
            double ramPamet = P * (videokarti * 0.10);

            double sumAll = videokarti + procesori + ramPamet;

            if (N > M)
            {
                sumAll = sumAll - (sumAll * 0.15);
            }
            if (budget >= sumAll)
            {
                Console.WriteLine($"You have {budget - sumAll:f2} leva left!");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {sumAll - budget:f2} leva more!");
            }
        }
    }
}
