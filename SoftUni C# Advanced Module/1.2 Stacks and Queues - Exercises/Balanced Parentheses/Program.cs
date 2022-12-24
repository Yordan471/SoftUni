using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balanced_Parentheses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string parentheses = Console.ReadLine();
            
            Stack<char> stack = new Stack<char>();
           
            foreach(char ch in parentheses)
            {
                if (stack.Any())
                {
                    char checkSymbol = stack.Peek();

                    if (checkSymbol == '(' && ch == ')')
                    {
                        stack.Pop();
                        continue;
                    }
                    else if (checkSymbol == '{' && ch == '}')
                    {
                        stack.Pop();
                        continue;
                    }
                    else if (checkSymbol == '[' && ch == ']')
                    {
                        stack.Pop();
                        continue;
                    }
                }

                stack.Push(ch);
            }

            if (stack.Count > 0)
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");
            }
        }
    }
}
