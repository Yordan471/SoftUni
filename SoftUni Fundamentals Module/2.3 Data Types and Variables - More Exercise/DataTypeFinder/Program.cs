using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypeFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var command = Console.ReadLine();

            while (true)      
            {

                if (command == "END")
                {
                    break;
                }

                if (int.TryParse(command, out _))
                {
                    Console.WriteLine($"{command} is integer type");
                }
                else if (double.TryParse(command, out _))
                {
                    Console.WriteLine($"{command} is floating point type");
                }
                else if (char.TryParse(command, out _))
                {
                    Console.WriteLine($"{command} is character type");
                }
                else if (bool.TryParse(command, out _))
                {
                    Console.WriteLine($"{command} is boolean type");
                }
                else
                {
                    Console.WriteLine($"{command} is string type");
                }

                command = Console.ReadLine();
            }              
        }
    }
}
