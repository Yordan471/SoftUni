using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] firstArray = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            int[] secondArray = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            bool identical = true;
            int counter = -1;
            int sum = 0;

            for (int i = 0; i < firstArray.Length; i++)
            {
                counter++;

                sum += firstArray[i];

                if (firstArray[i] == secondArray[i])
                {
                    identical = true;
                }
                else
                {
                    identical = false;
                    break;
                }
            }

            if (identical)
            {
                Console.WriteLine($"Arrays are identical. Sum: {sum}");
            }
            else
            {
                Console.WriteLine($"Arrays are not identical. Found difference at {counter} index");
            }
        }
    }
}
