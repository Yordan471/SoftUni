using System;

namespace PasswordGuess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" ");
            string password = Console.ReadLine();
            string truepass = "s3cr3t!P@ssw0rd";
            if (password == truepass)
            {
                Console.WriteLine("Welcome");
            }
            else
            {
                Console.WriteLine("Wrong password!");
            }
        }
    }
}
