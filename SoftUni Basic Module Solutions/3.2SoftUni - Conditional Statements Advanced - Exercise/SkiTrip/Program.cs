using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiTrip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string place = Console.ReadLine();
            string expression = Console.ReadLine();

            decimal roomForOne = 18.00M;
            decimal apartment = 25.00M;
            decimal presidentRoom = 35.00M;
            decimal Price = 0.00M;

            switch (place)
            {
                case "room for one person":
                     Price = (days - 1) * roomForOne;

                        if (expression == "positive")
                        {
                        Price += Price * 0.25M;
                        }
                        else if (expression == "negative")
                        {
                        Price -= Price * 0.1M;
                        }
                    break;

                case "apartment":
                    Price = (days - 1) * apartment;

                    if (days < 10)
                    {
                        Price -= Price * 0.3M;
                        if (expression == "positive")
                        {
                            Price += Price * 0.25M;
                        }
                        else
                        {
                            Price -= Price * 0.1M;
                        }
                    }
                    else if (days > 10 && days < 15)
                    {
                        Price -= Price * 0.35M;
                        if (expression == "positive")
                        {
                            Price += Price * 0.25M;
                        }
                        else
                        {
                            Price -= Price * 0.1M;
                        }
                    }
                    else
                    {
                        Price -= Price * 0.5M;
                        if (expression == "positive")
                        {
                            Price += Price * 0.25M;
                        }
                        else
                        {
                            Price -= Price * 0.1M;
                        }
                    }
                    break;

                case "president apartment":
                    Price = (days - 1) * presidentRoom;

                    if (days < 10)
                    {
                        Price -= Price * 0.1M;                  
                        if (expression == "positive")
                        {
                             Price += Price * 0.25M;                            
                        }
                        else
                        {
                              Price -= Price * 0.1M;
                        }
                    }   
                    else if (days > 10 && days < 15)
                    {
                        Price -= Price * 0.15M;
                        if (expression == "positive")
                        {
                            Price += Price * 0.25M;
                        }
                        else
                        {
                            Price -= Price * 0.1M;
                        }
                    }
                    else
                    {
                        Price -= Price * 0.20M;
                        if (expression == "positive")
                        {
                            Price += Price * 0.25M;
                        }
                        else
                        {
                            Price -= Price * 0.1M;
                        }
                    }
                    break;
            }
            Console.WriteLine($"{Price:f2}"); 
        }
    }
}
