using System;

namespace ConcatenateData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" ");
            string firstName = Console.ReadLine();
            Console.WriteLine(" ");
            string lastName = Console.ReadLine();
            Console.WriteLine(" ");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine(" ");
            string town = Console.ReadLine();

            Console.WriteLine($"You are {firstName} {lastName}, a {age}-years old person from {town}.");
        }
    }
}
