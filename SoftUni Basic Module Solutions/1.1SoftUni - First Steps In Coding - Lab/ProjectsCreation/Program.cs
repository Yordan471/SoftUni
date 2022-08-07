using System;

namespace ProjectsCreation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int projects = int.Parse(Console.ReadLine());
            int time = projects * 3;

            Console.WriteLine($"The architect {name} will need {time} " +
                $"hours to complete {projects} project/s.");
        }
    }
}
