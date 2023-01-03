using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odd_Lines
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("input.txt");

            while (true)
            {
                string line = reader.ReadLine();

                if (line == null)
                {
                    break;
                }

                Console.WriteLine(line);
            }
        }
    }
}
