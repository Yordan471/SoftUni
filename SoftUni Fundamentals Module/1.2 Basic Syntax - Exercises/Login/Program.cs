using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();

            string truePassword = "";
            int counter = 0;
            bool correctPass = false;
            bool tooManyAttempts = false;

            for (int i = 0; i <= username.Length - 1; i++)
            {
                char letter = username[username.Length - 1 - i];
                truePassword += letter;
            }
          
            while (true)
            {
                string password = Console.ReadLine();

                counter++;

                if (password == truePassword)
                {
                    correctPass = true;
                    break;
                }
                else if (password != truePassword)
                {
                    if (counter == 4)
                    {
                        tooManyAttempts = true;
                        break;
                    }

                    Console.WriteLine($"Incorrect password. Try again.");
                }
            }

            if (correctPass)
            {
                Console.WriteLine($"User {username} logged in.");
            }
            else if (tooManyAttempts)
            {
                Console.WriteLine($"User {username} blocked!");
            }
        }
    }
}
