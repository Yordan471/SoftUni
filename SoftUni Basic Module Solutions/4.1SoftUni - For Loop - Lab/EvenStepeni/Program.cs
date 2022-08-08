using System;

namespace EvenStepeni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int number = 1;

            for (int i = 0; i <= n; i += 2)
            {               
                Console.WriteLine(number);
                number = number * 2 * 2;
            }
        }
    }
}
