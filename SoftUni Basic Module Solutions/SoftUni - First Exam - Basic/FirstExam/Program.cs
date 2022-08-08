using System;

namespace Excursion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            int numForNights = int.Parse(Console.ReadLine());
            int numTransportTickets = int.Parse(Console.ReadLine());
            int numMuseumTickets = int.Parse(Console.ReadLine());

            int forNight = 20;
            double transportTicket = 1.60;
            int museumTicket = 6;

            double sum = numForNights * forNight + numTransportTickets * transportTicket + numMuseumTickets * museumTicket;
            double sumXPeople = sum * numberOfPeople;
            double result = sumXPeople + (sumXPeople * 0.25);

            Console.WriteLine($"{result:f2}");
        }
    }
}
