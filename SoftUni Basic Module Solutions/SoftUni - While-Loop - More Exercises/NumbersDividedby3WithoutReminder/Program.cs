using System;

namespace NumbersDividedby3WithoutReminder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = 0;

            while (num != 100)
            {
                num++;
                if (num % 3 == 0)
                {
                    Console.WriteLine(num);
                }
            }
        }
    }
}
