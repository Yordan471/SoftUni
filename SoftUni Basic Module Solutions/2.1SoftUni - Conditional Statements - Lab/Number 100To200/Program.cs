using System;

namespace Number_100To200
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" ");
            int num = int.Parse(Console.ReadLine());

            if (num < 100)
            {
                Console.WriteLine("Less than 100");
            }
            if (num >= 100 && num <= 200)
            {
                Console.WriteLine("Between 100 and 200");
            }
            if (num > 200)
            {
                Console.WriteLine("Greater than 200");
            }
        }
    }
}
