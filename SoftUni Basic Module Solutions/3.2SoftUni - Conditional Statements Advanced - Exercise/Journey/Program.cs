using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journey
{
    public class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            double cost = 0.0;

            string place = "";
            string destination = "";
            if (budget <= 100)
            {
                destination = "Bulgaria";
                {
                    if (season == "summer")
                    {
                        cost += budget * 0.30;
                        place = "Camp";
                    }
                    else if (season == "winter")
                    {
                        cost += budget * 0.70;
                        place = "Hotel";
                    }
                }
            }
            else if (budget <= 1000)
            {
                destination = "Balkans";
                {
                    if (season == "summer")
                    {
                        cost += budget * 0.40;
                        place = "Camp";
                    }
                    else if ( season == "winter")
                    {
                        cost += budget * 0.80;
                        place = "Hotel";
                    }
                }
            }
            else if (budget > 1000)
            {
                destination = "Europe";
                cost += budget * 0.90;
                place = "Hotel";
            }
            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{place} - {cost:f2}");
        }
    }
}
