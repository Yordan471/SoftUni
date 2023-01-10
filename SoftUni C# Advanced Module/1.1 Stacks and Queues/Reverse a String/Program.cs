using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverse_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> stack = new Stack<char>();
            StringBuilder sb = new StringBuilder();

            foreach (char c in input)
            {
                stack.Push(c);
            }

            while (stack.Count > 0)
            {
                sb.Append(stack.Peek().ToString());
                stack.Pop();
            }

            Console.WriteLine(sb);
        }
    }
}
