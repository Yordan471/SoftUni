using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitShop
{
    public class Program
    {
        static void Main(string[] args)
        {
            double banana = 0.0; double apple = 0.0; double orange = 0.0;
            double grapefruit = 0.0; double kiwi = 0.0;
            double pineapple = 0.0; double grapes = 0.0;

            string fruit = Console.ReadLine();
            string days = Console.ReadLine();
            Console.Write("");
            double quantity = double.Parse(Console.ReadLine());

            if (days == "Monday" || days == "Tuesday" || days == "Wednesday"
                || days == "Thursday" || days == "Friday")
            {
                banana += 2.5;  apple += 1.2;  orange += 0.85;
                grapefruit += 1.45;  kiwi += 2.7;
                pineapple += 5.5;  grapes += 3.85;
            }
            else if (days == "Saturday" || days == "Sunday")
            {
                 banana += 2.7;  apple += 1.25;  orange += 0.90;
                 grapefruit += 1.60;  kiwi += 3;
                 pineapple += 5.6;  grapes += 4.20;
            }
             else
            {
                Console.WriteLine("error");
                return;
            }              
            double quanBanana = banana * quantity;
            double quanApple = apple * quantity;
            double quanOrange = orange * quantity;
            double quanGrapefruit = grapefruit * quantity;
            double quanKiwi = kiwi * quantity;
            double quanPin = pineapple * quantity;
            double quanGrapes = grapes * quantity;

            switch (fruit)
            {
                case "banana":
                    Console.WriteLine($"{quanBanana:f2}"); break;
                case "apple":
                    Console.WriteLine($"{quanApple:f2}"); break;
                case "orange":
                    Console.WriteLine($"{quanOrange:f2}"); break;
                case "grapefruit":
                    Console.WriteLine($"{quanGrapefruit:f2}"); break;
                case "kiwi":
                    Console.WriteLine($"{quanKiwi:f2}"); break;
                case "pineapple":
                    Console.WriteLine($"{quanPin:f2}"); break;
                case "grapes":
                    Console.WriteLine($"{quanGrapes:f2}"); break;
                default:
                    Console.WriteLine("error"); break;
            }
        }
    }
}
