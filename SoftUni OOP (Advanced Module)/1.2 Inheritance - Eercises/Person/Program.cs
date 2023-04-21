using System;

namespace Person
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Child child = new(name, age);
            Person person = new(name, age);

            if (age > 15)
            {
                Console.WriteLine(person);
            }
            else
            {
                Console.WriteLine(child);
            }
        }
    }
}