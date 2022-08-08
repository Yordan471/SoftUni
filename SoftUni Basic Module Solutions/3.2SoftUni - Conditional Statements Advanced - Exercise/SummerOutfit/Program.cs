using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerOutfit
{
    public class Program
    {
        static void Main(string[] args)
        {
            double gradusi = double.Parse(Console.ReadLine());
            string dayTime = Console.ReadLine();
            
            string outfit = "";
            string shoes = "";

            if (gradusi >= 10 && gradusi <= 18)
            {
                if (dayTime == "Morning")
                {
                    outfit = "Sweatshirt";  shoes = "Sneakers";
                }
                else if (dayTime == "Afternoon" || dayTime == "Evening")
                {
                    outfit = "Shirt";  shoes = "Moccasins";
                }
            }
            if (gradusi > 18 && gradusi <= 24)
            {
                if (dayTime == "Morning" || dayTime == "Evening")
                {
                    outfit = "Shirt";  shoes = "Moccasins";
                }
                if (dayTime == "Afternoon")
                {
                    outfit = "T-Shirt";  shoes = "Sandals";
                }                
            }
            if (gradusi >= 25)
            {
                if (dayTime == "Morning")
                {
                    outfit = "T-Shirt";  shoes = "Sandals";
                }
                if (dayTime == "Afternoon")
                {
                    outfit = $"Swim Suit"; shoes = "Barefoot";
                }
                if (dayTime == "Evening")
                {
                    outfit = "Shirt";  shoes = "Moccasins";
                }
            }
            Console.WriteLine($"It's {gradusi} degrees, get your {outfit} and {shoes}.");
        }
    }
}
