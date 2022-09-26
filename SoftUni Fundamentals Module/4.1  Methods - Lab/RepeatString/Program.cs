using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepeatString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            int repeatWord = int.Parse(Console.ReadLine());

            Console.WriteLine(RepeatWord(word, repeatWord));
        }

        static string RepeatWord(string word, int repeatWord)
        {
            string result = String.Empty;

            for (int i = 0; i < repeatWord; i++)
            {
                result += word;
            }

            return result;
        }
    }
}
