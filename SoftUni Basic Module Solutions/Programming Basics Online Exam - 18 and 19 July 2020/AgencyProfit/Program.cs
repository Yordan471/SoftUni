using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgencyProfit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nameCompany = Console.ReadLine();
            int numberTicketsAdults = int.Parse(Console.ReadLine());
            int numberTicketsKids = int.Parse(Console.ReadLine());
            double nettPriceAdults = double.Parse(Console.ReadLine());
            double tax = double.Parse(Console.ReadLine());

            double priceForAllTicketsAdults = numberTicketsAdults * 1.0 * (nettPriceAdults + tax);
            double priceForOneTicketKids = nettPriceAdults * 0.30;
            double priceForAllTicketsKids = (priceForOneTicketKids + tax) * numberTicketsKids;
            double resultPrice = (priceForAllTicketsAdults + priceForAllTicketsKids) * 0.20;

            Console.WriteLine($"The profit of your agency from {nameCompany} tickets is {resultPrice:f2} lv.");
        }
    }
}

