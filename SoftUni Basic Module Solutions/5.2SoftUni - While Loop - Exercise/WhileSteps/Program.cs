using System;

namespace WhileSteps
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int totalSteps = 0;

            while (totalSteps < 10000)
            {
                string input = (Console.ReadLine());

                if (input == "Going home")
                {
                    int lastSteps = int.Parse(Console.ReadLine());
                    totalSteps += lastSteps;
                    break;
                }
                int steps = int.Parse(input);

                totalSteps += steps;
            }
            if (totalSteps >= 10000)
            {
                int moreSteps = totalSteps - 10000;
                Console.WriteLine($"Goal reached! Good job!");
                Console.WriteLine($"{moreSteps} steps over the goal!");
            }
            else
            {
                int lastSteps = 10000 - totalSteps;
                Console.WriteLine($"{lastSteps} more steps to reach goal.");

            }
        }  
    }
}
