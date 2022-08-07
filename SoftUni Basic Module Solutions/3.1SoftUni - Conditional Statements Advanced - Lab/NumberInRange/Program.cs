using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberInRange
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("");
            int number = int.Parse(Console.ReadLine());

            if (number <= 100 && number >= -100 && number !=0)
            {
                Console.WriteLine("Yes");
            }
            else if (number !=0)
            {
                Console.WriteLine("No");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
