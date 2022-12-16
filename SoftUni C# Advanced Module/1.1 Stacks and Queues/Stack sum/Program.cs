using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Stack_sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arrayOfInts = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            Stack<int> ints= new Stack<int>(arrayOfInts);

            string command = string.Empty;

            while ((command = Console.ReadLine().ToLower()) != "end")
            {
                string[] commandToArray = command
                    .Split();

                string operation = commandToArray[0];

                if (operation == "add")
                {
                    int firstNum = int.Parse(commandToArray[1]);
                    int secondNum = int.Parse(commandToArray[2]);

                    ints.Push(firstNum);
                    ints.Push(secondNum);
                }
                else if (operation == "remove")
                {
                    int count = int.Parse(commandToArray[1]);
                   
                    for (int i = 0; i < count; i++)
                    {
                        if (count <= ints.Count)
                        {
                            ints.Pop();
                        }
                    }
                }
            }

            int sum = ints.Sum();
            Console.WriteLine(sum);
        }
    }
}
