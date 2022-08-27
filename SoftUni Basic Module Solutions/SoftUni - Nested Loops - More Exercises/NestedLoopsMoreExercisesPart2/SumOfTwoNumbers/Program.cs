using System;

namespace SumOfTwoNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int beginningInterval = int.Parse(Console.ReadLine());
            int endingInterval = int.Parse(Console.ReadLine());
            int magicNum = int.Parse(Console.ReadLine());

            int counter = 0;
            int result = 0;
            bool found = false;

            for (int i = beginningInterval; i <= endingInterval; i++)
            {
                for (int j = beginningInterval; j <= endingInterval; j++)
                {
                    counter++;
                    result = i + j;

                    if (result == magicNum)
                    {
                        Console.WriteLine($"Combination N:{counter} ({i} + {j} = {result})");
                        found = true;
                    }
                    
                    if (found)
                    {
                        break;
                    }
                }
                if (found)
                {
                    break;
                }    
            }
            if (!found)
            {
                Console.WriteLine($"{counter} combinations - neither equals {magicNum}");
            }
        }
    }
}
