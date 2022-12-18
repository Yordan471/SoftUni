using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Text_Editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());

            string text = string.Empty;
            Stack<string> stack = new Stack<string>();

            stack.Push(string.Empty);
            
            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(' ');
                
                string operation = command[0];

                if (operation == "1")
                {
                    string someString = command[1];

                    text += someString;
                    stack.Push(text);
                }
                else if (operation == "2")
                {
                    int count = int.Parse(command[1]);

                    text = text.Remove(text.Length - 1 - count + 1);
                    stack.Push(text);
                }
                else if (operation == "3")
                {
                    int index = int.Parse(command[1]);

                    Console.WriteLine($"{text[index - 1]}");
                }
                else if (operation == "4")
                {
                    stack.Pop();

                    string currText = stack.Peek();
                    text = currText;
                }
            }
        }
    }
}
