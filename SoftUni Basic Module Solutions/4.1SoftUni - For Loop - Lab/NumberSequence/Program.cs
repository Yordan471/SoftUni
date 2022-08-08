using System;

namespace NumberSequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            
            var min = 100000000;
            var max = -100000000;

            for(var i = 0; i < n; i++)
            {
                var number = int.Parse(Console.ReadLine());
                if (number < min)
                {
                    min = number;
                }
                if (number > max)
                {
                    max = number;
                }                        
            }
            Console.WriteLine("Max number: {0}", max);
            Console.WriteLine("Min number: {0}", min);
        }
    }
}
