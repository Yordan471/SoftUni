using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace randomdd
{
    internal class Program
    {
        static void Main(string[] args)
        {           
                double priceOfTrip = double.Parse(Console.ReadLine());
                int puzzle = int.Parse(Console.ReadLine());
                int dolls = int.Parse(Console.ReadLine());
                int bears = int.Parse(Console.ReadLine());
                int minions = int.Parse(Console.ReadLine());
                int trucks = int.Parse(Console.ReadLine());
                int numberOfAll = puzzle + dolls + bears + minions + trucks;
                double priceOfAll = (puzzle * 2.60) + (dolls * 3) + (bears * 4.1) + (minions * 8.2) + (trucks * 2);
                double discount = priceOfAll * 0.25;
                if (numberOfAll >= 50)
                {
                    priceOfAll = priceOfAll - discount;
                }
                else
                {
                    priceOfAll = priceOfAll * 1;
                }
                double pechalba = priceOfAll - (priceOfAll * 0.1);
                if (pechalba >= priceOfTrip)
                {
                    Console.WriteLine($"Yes! {pechalba - priceOfTrip:f2} lv left.");
                }
                else
                {
                    Console.WriteLine($"Not enough money! {priceOfTrip - pechalba:f2} lv needed.");
                }
            }
        }
    }

    
