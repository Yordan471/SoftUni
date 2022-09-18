using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());

            double wholeCourses = Math.Ceiling(n * 1.0 / p);
            double additionalcourse = n % wholeCourses;

            Console.WriteLine(wholeCourses);
        }
    }
}
