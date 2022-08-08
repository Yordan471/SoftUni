using System;

namespace USDtoBGN
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double usd = double.Parse(Console.ReadLine());

            double convert = usd * 1.79549;

            Console.WriteLine(convert);
        }
    }
}
