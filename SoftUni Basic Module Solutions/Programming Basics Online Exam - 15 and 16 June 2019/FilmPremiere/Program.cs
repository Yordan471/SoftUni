using System;

namespace FilmPremiere
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string projection = Console.ReadLine();
            string packageForProjection = Console.ReadLine();
            int numTickets = int.Parse(Console.ReadLine());

            double sum = 0;

            if (projection == "John Wick")
            {
                switch (packageForProjection)
                {
                    case "Drink":
                        sum += 12;
                        break;
                    case "Popcorn":
                        sum += 15;
                        break;
                    case "Menu":
                        sum += 19;
                        break;
                }

            }
            else if (projection == "Star Wars")
            {
                switch (packageForProjection)
                {
                    case "Drink":
                        sum += 18;
                        break;
                    case "Popcorn":
                        sum += 25;
                        break;
                    case "Menu":
                        sum += 30;
                        break;
                }
            }
            else if (projection == "Jumanji")
            {
                switch (packageForProjection)
                {
                    case "Drink":
                        sum += 9;
                        break;
                    case "Popcorn":
                        sum += 11;
                        break;
                    case "Menu":
                        sum += 14;
                        break;
                }
            }

            double sumForProjection = sum * numTickets;

            if (projection == "Star Wars" && numTickets >= 4)
            {
                sumForProjection *= 0.70;
            }
            else if (projection == "Jumanji" && numTickets == 2)
            {
                sumForProjection *= 0.85;
            }

            Console.WriteLine($"Your bill is {sumForProjection:f2} leva.");
        }
    }
}
