using System;

namespace Repainting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double predNailon = 1.50;
            double boq = 14.50;
            double razreditel = 5.00;
            double addBoqNailon = 0.1;
            double addtorbichki = 0.40;

            int neobhNailon = int.Parse(Console.ReadLine());
            int neobhBoq = int.Parse(Console.ReadLine());
            int neobhRazreditel = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());

            double nailonPrice = (neobhNailon + 2) * predNailon;
            double boqPrice = (neobhBoq + neobhBoq * addBoqNailon) * boq;
            double razreditelPrice = razreditel * neobhRazreditel;

            double fullPrice = nailonPrice + boqPrice + razreditelPrice + addtorbichki;
            double fullPriceWorkers = (fullPrice * 0.30) * hours;
            double fullPriceNeeded = fullPriceWorkers + fullPrice;

            Console.WriteLine(fullPriceNeeded);
        }
    }
}
