using System;

namespace PetShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" ");
            int dogpack = int.Parse(Console.ReadLine());
            Console.WriteLine(" ");
            int catpack = Convert.ToInt32(Console.ReadLine());

            double dog = 2.5;
            int cat = 4;

            double price = dog * dogpack + cat * catpack;

            Console.WriteLine(price + " " + "lv.");
        }
    }
}
