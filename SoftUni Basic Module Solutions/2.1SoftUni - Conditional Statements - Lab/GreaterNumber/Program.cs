using System;

namespace GreaterNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" ");
            double x = double.Parse(Console.ReadLine());

            Console.WriteLine(" ");
            double y = double.Parse(Console.ReadLine());

            if (x > y)
            {
                Console.WriteLine(x);
            }
            else
            {
                Console.WriteLine(y);
            }
        }
    }
}
