using System;
using System.IO;

class GFG
{

    // Main Method
    public static void Main()
    {
        int age;
        string name;

        Console.WriteLine("Enter your name: ");

        // using the method
        // typecasting not needed
        // as ReadLine returns string
        name = Console.ReadLine();

        Console.WriteLine("Enter your age: ");

        // Converted string to int
        age = Convert.ToInt32(Console.ReadLine());

        if (age >= 18)
        {
            Console.WriteLine("Hello " + name + "!"
                        + " You can vote");
        }
        else
        {
            Console.WriteLine("Hello " + name + "!"
                + " Sorry you can't vote");
        }
    }
}