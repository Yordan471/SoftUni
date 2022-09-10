using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldSnookerChampionship
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string stage = Console.ReadLine();
            string ticketType = Console.ReadLine();
            int numberOfTickets = int.Parse(Console.ReadLine());
            string pictureWithTrophey = Console.ReadLine();

            double sum = 0.0;
            double picture = 40.00;
            double savePrice = 0.0;

            if (stage == "Quarter final")
            {
                switch (ticketType)
                {
                    case "Standard":
                        sum += 55.50;
                        break;
                    case "Premium":
                        sum += 105.20;
                        break;
                    case "VIP":
                        sum += 118.90;
                        break;
                }
            }
            else if (stage == "Semi final")
            {
                switch (ticketType)
                {
                    case "Standard":
                        sum += 75.88;
                        break;
                    case "Premium":
                        sum += 125.22;
                        break;
                    case "VIP":
                        sum += 300.40;
                        break;
                }
            }
            else if (stage == "Final")
            {
                switch (ticketType)
                {
                    case "Standard":
                        sum += 110.10;
                        break;
                    case "Premium":
                        sum += 160.66;
                        break;
                    case "VIP":
                        sum += 400.00;
                        break;
                }
            }

            double priceForAllTickets = sum * numberOfTickets;
            savePrice = priceForAllTickets;

            if (priceForAllTickets > 4000)
            {
                priceForAllTickets *= 0.75;
            }
            else if (priceForAllTickets > 2500 && priceForAllTickets < 4001)
            {
                priceForAllTickets *= 0.90;
            }

            if (pictureWithTrophey == "Y" && savePrice < 4001)
            {
                priceForAllTickets += picture * numberOfTickets;
            }

            Console.WriteLine($"{priceForAllTickets:f2}");
        }
    }
}
