using System;

namespace Sequence2k_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int number2 = 1;
            while (number2 <= number)
            {
                Console.WriteLine(number2);
                number2 = 2 * number2 + 1;
            }
        }
    }
}
