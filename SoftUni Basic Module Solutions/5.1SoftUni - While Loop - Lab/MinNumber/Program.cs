using System;

namespace MinNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string commandNum = Console.ReadLine();

            int minNumber = 1000000;

            while (commandNum != "Stop")
            {
                int numbers = int.Parse(commandNum);

                if (minNumber > numbers)
                {
                    minNumber = numbers;
                }
                commandNum = Console.ReadLine();
            }

            Console.WriteLine(minNumber);
        }
    }
}
