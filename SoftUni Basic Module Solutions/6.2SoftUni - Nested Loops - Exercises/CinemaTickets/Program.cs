using System;

namespace CinemaTickets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            int totalTicketsForDay = 0;
            int studentTickets = 0;
            int standardTickets = 0;
            int kidTickets = 0;

            while (input != "Finish")
            {
                input = Console.ReadLine();

                if (input == "Finish")
                {
                    break;
                }

                string filmTitle = input;

                int seatsAvailable = int.Parse(Console.ReadLine());

                int currentAvailableSeats = seatsAvailable;

                string ticketType = "";
                int ticketsSoldForFilm = 0;

                while (ticketType != "End" && currentAvailableSeats > 0)
                {
                    ticketType = Console.ReadLine();

                    if (ticketType == "End")
                    {
                        break;
                    }

                    ticketsSoldForFilm++;
                    totalTicketsForDay++;
                    currentAvailableSeats--;

                    switch (ticketType)
                    {
                        case "standard":
                            standardTickets++;// при закупуване на стандартен билет - 1+
                            break;                          
                        case "student":
                            studentTickets++;
                            break;
                        case "kid":
                            kidTickets++;
                            break;
                    }
                }

                double percentageFull = ticketsSoldForFilm / (seatsAvailable * 1.0) * 100;
                Console.WriteLine($"{filmTitle} - {percentageFull:f2}% full.");
            }

            Console.WriteLine($"Total tickets: {totalTicketsForDay}");

            double percStudents = studentTickets / (totalTicketsForDay * 1.0) * 100;
            Console.WriteLine($"{percStudents:f2}% student tickets.");

            double percStandard = standardTickets / (totalTicketsForDay * 1.0) *100;
            Console.WriteLine($"{percStandard:f2}% standard tickets.");

            double percKid = kidTickets / (totalTicketsForDay * 1.0) * 100;
            Console.WriteLine($"{percKid:f2}% kids tickets.");
        }
    }
}
