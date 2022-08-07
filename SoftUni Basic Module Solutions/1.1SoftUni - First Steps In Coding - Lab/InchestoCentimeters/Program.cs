using System;

namespace InchestoCentimeters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" ");
            double x = double.Parse(Console.ReadLine());

            double y = x * 2.54;
            Console.WriteLine(y);
        }
    }
}
