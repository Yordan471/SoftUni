using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasterTrip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            string dates = Console.ReadLine();
            int numNights = int.Parse(Console.ReadLine());

            double sum = 0;

            if (destination == "France")
            {
                switch (dates)
                {
                    case "21-23":
                        sum += 30;
                        break;
                    case "24-27":
                        sum += 35;
                        break;
                    case "28-31":
                        sum += 40;
                        break;                      
                }
            }
            else if (destination == "Italy")
            {
                switch (dates)
                {
                    case "21-23":
                        sum += 28;
                        break;
                    case "24-27":
                        sum += 32;
                        break;
                    case "28-31":
                        sum += 39;
                        break;
                }
            }
            else if (destination == "Germany")
            {
                switch (dates)
                {
                    case "21-23":
                        sum += 32;
                        break;
                    case "24-27":
                        sum += 37;
                        break;
                    case "28-31":
                        sum += 43;
                        break;
                }
            }

            double sumResult = sum * numNights;
            Console.WriteLine($"Easter trip to {destination} : {sumResult:f2} leva.");
        }
    }
}
