using System;

namespace CinemaVoucher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int vaucherValue = int.Parse(Console.ReadLine());

            int neededMoney = 0;
            string itemName = "";
            int countItems = 0;
            int countTickets = 0;

            while ((itemName = Console.ReadLine()) != "End")
            {
                if (itemName.Length > 8)
                {
                    char a = itemName[0];
                    char b = itemName[1];
                    neededMoney += a + b;

                    if (neededMoney > vaucherValue)
                    {
                        break;
                    }
                    countTickets++;
                }
                else if (itemName.Length <= 8)
                {
                    char c = itemName[0];
                    neededMoney += c;

                    if (neededMoney > vaucherValue)
                    {
                        break;
                    }
                    countItems++;
                }
            }
            Console.WriteLine(countTickets);
            Console.WriteLine(countItems);
        }
    }
}
