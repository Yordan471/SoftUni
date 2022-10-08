using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            double priceWIthoutTaxes = 0;
            double taxes = 0;
            bool isSpecial = false;

            while (true)
            {
                if (command == "special" || command == "regular")
                {
                    if (command == "special")
                    {
                        isSpecial = true;
                    }

                    break;
                }

                double priceForPart = double.Parse(command);

                if (priceForPart <= 0)
                {
                    Console.WriteLine($"Invalid price!");
                }
                else
                {
                    priceWIthoutTaxes += priceForPart;
                }

                command = Console.ReadLine();          
            }

            taxes = priceWIthoutTaxes * 0.20;
            double totalPrice = taxes + priceWIthoutTaxes;
            
            if (isSpecial)
            {
                //We have 10% discount of the total price 
                //If the customer is special
                totalPrice *= 0.90;
            }

            if (totalPrice == 0)
            {
                Console.WriteLine($"Invalid order!");
            }
            else
            {
                Console.WriteLine($"Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: {priceWIthoutTaxes:f2}$");
                Console.WriteLine($"Taxes: {taxes:f2}$");
                Console.WriteLine("-----------");
                Console.WriteLine($"Total price: {totalPrice:f2}$");
            }
        }
    }
}
