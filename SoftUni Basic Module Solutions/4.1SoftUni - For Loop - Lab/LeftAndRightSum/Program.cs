using System;

namespace LeftAndRightSum
{
    internal class Program
    {
        static void Main(string[] args)
        {           
            int n = int.Parse(Console.ReadLine());
            int sumRight = 0;
            int sumLeft = 0;

            for (int i = 0; i < n; i++)
            {
                sumRight += int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < n; i++)
            {
                sumLeft += int.Parse(Console.ReadLine());
            }
            if (sumRight == sumLeft)
            {
                Console.WriteLine("Yes, sum = {0}", sumRight);
            }
            else
            {
                Console.WriteLine("No, diff = {0}", Math.Abs(sumRight - sumLeft));
            }            
        }
    }
}
