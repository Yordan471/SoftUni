using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharsToString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string letterOne = Console.ReadLine();
            char letterTwo = char.Parse(Console.ReadLine());
            char letterThree = char.Parse(Console.ReadLine());

            string word = (letterOne + letterTwo + letterThree);
            Console.WriteLine(word);
        }
    }
}
