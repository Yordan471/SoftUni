using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());

            decimal studioPrice = 00.00M;
            decimal apartmentPrice = 00.00M;
            decimal studioR = 0.00M;
            decimal apartmentR = 0.00M;

            switch (month)
            {
                case ("May"):
                case ("October"):
                    studioPrice = 50.00M;
                    apartmentPrice = 65.00M;

                    studioR = studioPrice * nights;
                    apartmentR = apartmentPrice * nights;

                    if (nights > 14)
                    {
                        studioR *= 0.70M;
                        apartmentR *= 0.90M;
                    }
                    else if (nights > 7)
                    {
                        studioR *= 0.95M;
                    }
                    break;

                case ("June"):
                case ("September"):
                    studioPrice = 75.20M;
                    apartmentPrice = 68.70M;

                    studioR = studioPrice * nights;
                    apartmentR = apartmentPrice * nights; ;

                    if (nights > 14)
                    {
                        studioR *= 0.8M;
                        apartmentR *= 0.90M;
                    }
                    break;

                case ("July"):
                case ("August"):
                    studioPrice = 76.00M;
                    apartmentPrice = 77.00M;

                    studioR = studioPrice * nights;
                    apartmentR = apartmentPrice * nights;

                    if (nights > 14)
                    {
                        apartmentR *= 0.90M;
                    }
                    break;            
            }
            Console.WriteLine($"Apartment: {apartmentR:f2} lv.");
            Console.WriteLine($"Studio: {studioR:f2} lv.");          
        }
    }
}