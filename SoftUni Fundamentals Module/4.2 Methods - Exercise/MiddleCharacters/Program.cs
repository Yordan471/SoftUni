using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleCharacters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string wordOrNumber = Console.ReadLine();

            MiddleChar(wordOrNumber);
        }

        static void MiddleChar (string wordOrNumber)
        {
            char[] array = wordOrNumber.ToCharArray();

            if (array.Length % 2 == 0)
            {
                Console.WriteLine((char)array[(array.Length / 2) - 1] + "" + (char)array[array.Length / 2]);
            }
            else if (array.Length % 2 != 0)
            {
                Console.WriteLine((char)array[(array.Length / 2)]);
            }    
        }
    }
}
