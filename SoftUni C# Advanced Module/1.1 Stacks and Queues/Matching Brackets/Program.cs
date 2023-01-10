using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matching_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<int> indexes = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    indexes.Push(i);
                }
                else if (input[i] == ')')
                {
                    int startIndex = indexes.Pop();
                    int endIndex = i;

                    string substringExpression = input.Substring(startIndex, endIndex - startIndex + 1);

                    Console.WriteLine(substringExpression);
                }
            }
        }
    }
}
