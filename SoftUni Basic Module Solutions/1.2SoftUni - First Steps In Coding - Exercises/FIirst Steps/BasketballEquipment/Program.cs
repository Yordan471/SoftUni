using System;

namespace BasketballEquipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int AnnualTax = int.Parse(Console.ReadLine());

            double shoes = AnnualTax * 0.60;
            double ekip = shoes * 0.80;
            double ball = ekip * 0.25;
            double aksesoari = ball * 0.20;

            double fullPrice = shoes + ekip + ball + aksesoari + AnnualTax;

            Console.WriteLine(fullPrice);
        }
    }
}
