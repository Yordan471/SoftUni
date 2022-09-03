using System;

namespace Cinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hallCapacity = int.Parse(Console.ReadLine());

            int numOfPeopleInHall = 0;
            int priceForATicket = 5;
            int counter = 0;
            double priceForMovie = 0;
            bool movieTime = false;
            bool noMoreSeats = false;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Movie time!")
                {
                    movieTime = true;
                    break;
                }

                int numPeople = int.Parse(command);

                if (numPeople % 3 == 0)
                {
                    counter++;
                }

                numOfPeopleInHall += numPeople;

                if (numOfPeopleInHall > hallCapacity)
                {
                    noMoreSeats = true;
                    numOfPeopleInHall -= numPeople;

                    if (numPeople % 3 == 0)
                    {
                        counter--;
                    }

                    break;
                }
            }

            priceForMovie = numOfPeopleInHall * priceForATicket;
            priceForMovie -= 5 * counter;


            if (movieTime)
            {
                int seatsLeft = hallCapacity - numOfPeopleInHall;
                Console.WriteLine($"There are {seatsLeft} seats left in the cinema.");
            }
            else if (noMoreSeats)
            {
                Console.WriteLine($"The cinema is full.");
            }

            Console.WriteLine($"Cinema income - {priceForMovie} lv.");
        }
    }
}
