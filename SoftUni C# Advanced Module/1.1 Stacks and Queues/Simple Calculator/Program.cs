using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(' ');

            Array.Reverse(input);

            Stack<string> stack = new Stack<string>(input);

            int result = int.Parse(stack.Pop());

            for (int i = 0; i < stack.Count; i++)
            {
                if (stack.Peek() == "-")
                {
                    stack.Pop();
                    result -= int.Parse(stack.Pop());
                    i--;
                }
                else
                {
                    stack.Pop();
                    result += int.Parse(stack.Pop());
                    i--;
                }
            }

            Console.WriteLine(result);
        }
    }
}
