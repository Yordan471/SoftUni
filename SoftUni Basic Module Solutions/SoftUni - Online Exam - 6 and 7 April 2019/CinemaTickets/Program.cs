using System;

namespace CinemaTickets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string movieName = Console.ReadLine();
          
            int counterStudent = 0;
            int counterAllStudentTickets = 0;
            int counterStandard = 0;
            int counterAllStandardTickets = 0;
            int counterKids = 0;
            int counterAllKidsTckets = 0;
            double allTickets = 0;
            double ticketsSoldForMovie = 0;
            double prctgSeatsForMovie = 0;

            while (movieName != "Finish")
            {              
                int freeSeatsForProjecton = int.Parse(Console.ReadLine());
                string ticketType = Console.ReadLine();
               
                for (int i = 1; i <= freeSeatsForProjecton; i++)
                {
                    if (ticketType == "End")
                    {
                        break;
                    }

                    if (ticketType == "student")
                    {
                        counterStudent++;
                        counterAllStudentTickets++;
                    }
                    else if (ticketType == "standard")
                    {
                        counterStandard++;
                        counterAllStandardTickets++;
                    }
                    else if (ticketType == "kid")
                    {
                        counterKids++;
                        counterAllKidsTckets++;
                    }

                    if (i == freeSeatsForProjecton)
                    {
                        break;
                    }

                    ticketType = Console.ReadLine();
                }

                ticketsSoldForMovie += counterStudent + counterStandard + counterKids;
                prctgSeatsForMovie = (ticketsSoldForMovie * 100) / freeSeatsForProjecton;

                Console.WriteLine($"{movieName} - {prctgSeatsForMovie:f2}% full.");

                allTickets += ticketsSoldForMovie;
                ticketsSoldForMovie = 0;
                counterStudent = 0;
                counterStandard = 0;
                counterKids = 0;

                movieName = Console.ReadLine();
            }

            Console.WriteLine($"Total tickets: {allTickets}");

            double prcntgStudentTickets = (counterAllStudentTickets * 100) / allTickets;
            Console.WriteLine($"{prcntgStudentTickets:f2}% student tickets.");

            double prcntgStandard = (counterAllStandardTickets * 100) / allTickets;
            Console.WriteLine($"{prcntgStandard:f2}% standard tickets.");

            double prcntgKids = (counterAllKidsTckets * 100) / allTickets;
            Console.WriteLine($"{prcntgKids:f2}% kids tickets.");
        }
    }
}
