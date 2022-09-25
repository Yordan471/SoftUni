using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            string group = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();

            double priceForSinglePerson = 0;

            if (dayOfWeek == "Friday")
            {
                switch (group)
                {
                    case "Students":
                        priceForSinglePerson += 8.45;
                        break;
                    case "Business":
                        priceForSinglePerson += 10.90;
                        break;
                    case "Regular":
                        priceForSinglePerson += 15;
                        break;
                }
            }
            else if (dayOfWeek == "Saturday")
            {
                switch (group)
                {
                    case "Students":
                        priceForSinglePerson += 9.80;
                        break;
                    case "Business":
                        priceForSinglePerson += 15.60;
                        break;
                    case "Regular":
                        priceForSinglePerson += 20;
                        break;
                }
            }
            else if (dayOfWeek == "Sunday")
            {
                switch (group)
                {
                    case "Students":
                        priceForSinglePerson += 10.46;
                        break;
                    case "Business":
                        priceForSinglePerson += 16;
                        break;
                    case "Regular":
                        priceForSinglePerson += 22.50;
                        break;
                }
            }

            double priceForAllPeople = priceForSinglePerson * numberOfPeople;

            if (group == "Students")
            {
                if (numberOfPeople >= 30)
                {
                    priceForAllPeople *= 0.85;
                }
            }
            else if (group == "Business")
            {
                if (numberOfPeople >= 100)
                {
                    priceForAllPeople = (numberOfPeople - 10) * priceForSinglePerson;
                }
            }
            else if (group == "Regular")
            {
                if (numberOfPeople >= 10 && numberOfPeople <= 20)
                {
                    priceForAllPeople *= 0.95;
                }
            }

            Console.WriteLine($"Total price: {priceForAllPeople:f2}");
        }
    }
}
