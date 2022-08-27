using System;

namespace SafePasswordsGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int maxNumGeneratedPass = int.Parse(Console.ReadLine());

            int counter = 0;
            int firstSymbol = 35;
            int secondSymbol = 64;
            bool over = false;

            for (int x = 1; x <= a; x++)
            {
                for (int y = 1; y <= b; y++)
                {
                    if (firstSymbol > 55)
                    {
                        firstSymbol = 35;
                    }

                    if (secondSymbol > 96)
                    {
                        secondSymbol = 64;
                    }

                    if (counter == maxNumGeneratedPass)
                    {
                        over = true;
                        break;
                    }
                    counter++;

                    Console.Write($"{(char)firstSymbol}{(char)secondSymbol}{x}{y}{(char)secondSymbol}{(char)firstSymbol}|");

                    firstSymbol++;
                    secondSymbol++;
                }  
                if (over)
                {
                    break;
                }
            }                      
        }
    }
}
