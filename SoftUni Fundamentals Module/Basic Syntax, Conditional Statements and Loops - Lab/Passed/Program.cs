using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passed
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float grade = float.Parse(Console.ReadLine());

            if (grade >= 3)
            {
                Console.WriteLine($"Passed!");
            }
        }
    }
}
