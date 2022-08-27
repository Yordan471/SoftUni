using System;

namespace TheSongOfTheWheels
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int numbersSum = 0;
            int counter = 0;
            bool isFourth = false;
            int a = 0;
            int b = 0;
            int c = 0;
            int d = 0;


            for (int i = 1; i <= 9; i++)
            {
                for (int j = 1; j <= 9; j++)
                {
                    for (int k = 1; k <= 9; k++)
                    {
                        for (int l = 1; l <= 9; l++)
                        {
                            numbersSum = i * j + k * l;

                            if (numbersSum == num)
                            {
                                if (i < j)
                                {
                                    if (k > l)
                                    {
                                        counter++;

                                        Console.Write($"{i}{j}{k}{l} ");
                                        
                                        if (counter == 4)
                                        {
                                            isFourth = true;
                                            a = i;
                                            b = j;
                                            c = k;
                                            d = l;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (counter > 0 && counter < 4)
            {
                Console.WriteLine();
            }

            if (isFourth)
            {
                Console.WriteLine();
                Console.WriteLine($"Password: {a}{b}{c}{d}");
            }
            else
            {
                Console.WriteLine($"No!");
            }          
        }
    }
}
