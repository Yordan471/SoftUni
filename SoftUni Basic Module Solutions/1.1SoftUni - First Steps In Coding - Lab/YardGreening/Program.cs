using System;

namespace YardGreening
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" ");
            double meters = double.Parse(Console.ReadLine());

            double num1 = 7.61;
            double withoutdisc = meters * num1;
            double discount = withoutdisc * 0.18;
            double result = withoutdisc - discount;

            Console.WriteLine(result + " " + "lv.");
            Console.WriteLine(discount + " " + "lv.");
        }
    }
}
