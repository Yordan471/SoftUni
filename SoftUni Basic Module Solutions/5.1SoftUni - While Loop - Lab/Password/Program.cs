using System;

namespace Password
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            string password = Console.ReadLine();

            string checkPass = Console.ReadLine();

            while (checkPass != password)
            {
                checkPass = Console.ReadLine();
            }
            Console.WriteLine($"Welcome {name}!");
        }
    }
}
