using System;

namespace carNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
          
            for (int i = num1; i <= num2; i++)
            {
                for (int j = num1; j <= num2; j++)
                {
                    for (int k = num1; k <= num2; k++)
                    {
                        for (int l = num1; l < i; l++)
                        {
                            if (i > l)
                            {
                                if (i % 2 == 0)
                                {
                                    if (l % 2 != 0)
                                    {
                                        if ((i - l) % 2 != 0 && (j + k) % 2 == 0)
                                        {
                                            Console.Write($"{i}{j}{k}{l} ");
                                        }
                                    }
                                }
                                else
                                {
                                    if (l % 2 == 0)
                                    {
                                        if (i % 2 != 0)
                                        {
                                            if ((i - l) % 2 != 0 && (j + k) % 2 == 0)
                                            {
                                                Console.Write($"{i}{j}{k}{l} ");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
