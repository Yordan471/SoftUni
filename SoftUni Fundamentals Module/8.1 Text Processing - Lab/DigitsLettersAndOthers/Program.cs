using System;
using System.Text;

namespace DigitsLettersAndOthers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            char[] chars = input.ToCharArray();

            StringBuilder digits = new StringBuilder();
            StringBuilder letters = new StringBuilder();
            StringBuilder others = new StringBuilder();

            foreach (char ch in chars)  
            {
                if (char.IsDigit(ch))
                {
                    digits.Append(ch);
                }
                else if (char.IsLetter(ch))
                {
                    letters.Append(ch);
                }
                else if (!char.IsLetterOrDigit(ch))
                {
                    others.Append(ch);
                }
            }

            Console.WriteLine($"{digits}\n{letters}\n{others}");
        }
    }
}
