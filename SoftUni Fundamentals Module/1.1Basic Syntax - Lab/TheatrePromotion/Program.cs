using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheatrePromotion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string typeOfDay = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            double price = 0;
            bool error = false;

            if (age >= 0 && age <= 18)
            {
                switch (typeOfDay)
                {
                    case "Weekday":
                        price += 12;
                        break;
                    case "Weekend":
                        price += 15;
                        break;
                    case "Holiday":
                        price += 5;
                        break;
                }
            }
            else if (age > 18 && age <= 64)
            {
                switch (typeOfDay)
                {
                    case "Weekday":
                        price += 18;
                        break;
                    case "Weekend":
                        price += 20;
                        break;
                    case "Holiday":
                        price += 12;
                        break;
                }
            }
            else if (age > 64 && age <= 122)
            {
                switch (typeOfDay)
                {
                    case "Weekday":
                        price += 12;
                        break;
                    case "Weekend":
                        price += 15;
                        break;
                    case "Holiday":
                        price += 10;
                        break;
                }
            }
            else
            {
                error = true;
            }

            if (error)
            {
                Console.WriteLine($"Error!");
            }
            else
            {
                Console.WriteLine($"{price}$");
            }
        }
    }
}
