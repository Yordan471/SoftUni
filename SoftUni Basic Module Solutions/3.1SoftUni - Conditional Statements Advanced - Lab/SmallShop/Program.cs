using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallShop
{
   public class Program
    {
        static void Main(string[] args)
        {
            double coffee = 0.0, water = 0.0, beer = 0.0, sweets = 0.0, peanuts = 0.0;

            Console.Write("");
            string product = Console.ReadLine(); 

            Console.Write("");
            string City = Console.ReadLine();

            Console.Write("");
            double quantity = double.Parse(Console.ReadLine());
     
            if (City == "Sofia")
            {
                coffee += 0.5; water += 0.8; beer += 1.2;
                sweets += 1.45; peanuts += 1.6;                                    
            }
            if (City == "Plovdiv")
            {
                coffee += 0.4; water += 0.7; beer += 1.15;
                sweets += 1.3; peanuts += 1.5;
            }
            if (City == "Varna")
            {
                coffee += 0.45; water += 0.7; beer += 1.1;
                sweets += 1.35; peanuts += 1.55;                      
            }
            double quanCoffee = coffee * quantity;
            double quanWater = water * quantity;
            double quanBeer = beer * quantity;
            double quanSweets = sweets * quantity;
            double quanPeanuts = peanuts * quantity;

            switch (product)
            {
                case "coffee":
                    Console.WriteLine(quanCoffee);
                    break;
                case "water":
                    Console.WriteLine(quanWater);
                    break;
                case "beer":
                    Console.WriteLine(quanBeer);
                    break;
                case "sweets":
                    Console.WriteLine(quanSweets);
                    break;
                case "peanuts":
                    Console.WriteLine(quanPeanuts);
                    break;
            }
        }
    }
}
