using System;

namespace Traveling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = "";

            while (command != "End")
            {
                command = Console.ReadLine();

                if (command == "End")
                {
                    return;
                }
                double minBudget = double.Parse(Console.ReadLine());

                double money = 0;
                string destination = command;

                while (money < minBudget)
                {
                    money += double.Parse(Console.ReadLine());
                    if (money >= minBudget)
                    {
                        Console.WriteLine($"Going to {destination}!");
                        break;
                    }
                }
            }
        }
    }
}
