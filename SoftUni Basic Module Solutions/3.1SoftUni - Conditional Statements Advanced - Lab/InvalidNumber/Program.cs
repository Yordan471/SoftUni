using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvalidNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("");
            int number = int.Parse(Console.ReadLine());

            if (number >= 100 && number <= 200 || number == 0 )
            {
                Console.WriteLine("");
            }
           else
            {
                Console.WriteLine("invalid");
            }              
        }
    }
}
