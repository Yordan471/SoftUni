using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewHause
{
    public class Program
    {
        static void Main(string[] args)
        {
            string Flowers = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());
           
            double discount = 0.0;
            double moneyNeeded = 0.0;
            double Roses = 5; double Dhalias = 3.8; double Tulips = 2.8;
            double Narcissus = 3; double Gladiolus = 2.5;

            switch (Flowers)
            {
                case "Roses":
                    moneyNeeded = quantity * Roses; break;
                case "Dahlias":
                    moneyNeeded = quantity * Dhalias; break;
                case "Tulips":
                    moneyNeeded = quantity * Tulips; break;
                case "Narcissus":
                    moneyNeeded = quantity * Narcissus; break;
                case "Gladiolus":
                    moneyNeeded = quantity * Gladiolus; break;
            }          
            if (quantity > 80)
            {
                if (Flowers == "Roses")
                {
                    discount += moneyNeeded * 0.1;
                }
                else if (Flowers == "Tulips")
                {
                    discount += moneyNeeded * 0.15;
                }
            }
            if (quantity < 80)
            {
                if (Flowers == "Gladiolus")
                {
                    discount -= moneyNeeded * 0.2;
                }           
            }
            if (quantity > 90)
            {
                if (Flowers == "Dahlias")
                {
                    discount += moneyNeeded * 0.15;
                }
            }
             if (quantity < 120)
            {
                if (Flowers == "Narcissus")
                {
                    discount -= moneyNeeded * 0.15;
                }
            }
            moneyNeeded = moneyNeeded - discount;
            
            if (budget >= moneyNeeded)
            {
                Console.WriteLine($"Hey, you have a great garden with {quantity} {Flowers} and {budget - moneyNeeded:f2} leva left.");
            }
            else if (moneyNeeded > budget)
            {
                Console.WriteLine($"Not enough money, you need { moneyNeeded-budget:f2} leva more.");
            }          
        }
    }
}
