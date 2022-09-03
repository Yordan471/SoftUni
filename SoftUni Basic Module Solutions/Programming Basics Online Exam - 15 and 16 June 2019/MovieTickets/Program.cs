using System;

namespace MovieTickets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a1 = int.Parse(Console.ReadLine());
            int a2 = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            for (char i = (char)a1; i <= a2 - 1; i++)
            {
                for (int j = 1; j <= n - 1; j++ )
                {
                    for (int k = 1; k <= n / 2 - 1; k++)
                    {
                        if (i % 2 == 0)
                        {
                            break;
                        }

                        if (i % 2 != 0 && (j + k + i) % 2 != 0)
                        {
                            Console.WriteLine($"{i}-{j}{k}{(int)i}");
                        }
                    }

                    if (i % 2 == 0)
                    {
                        break;
                    }
                }
            }
        }
    }
}
