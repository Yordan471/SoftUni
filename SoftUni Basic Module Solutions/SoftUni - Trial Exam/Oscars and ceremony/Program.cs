using System;

namespace Oscars_and_ceremony
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rentHall = int.Parse(Console.ReadLine());

            double figures = rentHall * 0.70;
            double catering = figures * 0.85;
            double sounding = catering * 0.50;

            double moneySpend = rentHall + figures + catering + sounding;

            Console.WriteLine($"{moneySpend:f2}");
        }
    }
}
