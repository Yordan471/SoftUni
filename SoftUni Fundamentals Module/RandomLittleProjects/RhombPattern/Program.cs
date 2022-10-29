using System;

namespace RhombPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int midPoint = number / 2 + 1;

            for (int i = 1; i <= number; i++)
            {
                for (int j = 1; j <= number; j++)
                {
                    if (j == midPoint || j == number - midPoint + 1)
                    {
                        Console.Write("$");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }

                if (i <= number / 2)
                {
                    midPoint--;
                }
                else
                {
                    midPoint++;
                }

                Console.WriteLine(" ");
            }

            Console.ReadLine();
        }
    }
}
