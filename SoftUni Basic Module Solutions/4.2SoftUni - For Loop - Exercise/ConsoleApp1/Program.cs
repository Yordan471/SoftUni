using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double age = double.Parse(Console.ReadLine());

            char genger = char.Parse(Console.ReadLine());

            if (genger == 'm')
            {
                if (age >= 16)
                {
                    Console.WriteLine("Mr.");
                }

                else
                {
                    Console.WriteLine("Master");
                }         
                
            }
            else if (genger == 'f')
            {
                if (age >= 16)
                {
                    Console.WriteLine("Ms.");
                }
                else
                {
                    Console.WriteLine("Miss");
                }
            }
        }
    }
}
