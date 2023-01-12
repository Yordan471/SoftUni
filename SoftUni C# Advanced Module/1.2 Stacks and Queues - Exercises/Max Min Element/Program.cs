using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max_Min_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfOperations = int.Parse(Console.ReadLine());

            Stack<int> numbers = new Stack<int>();

            for (int i = 0; i < numOfOperations; i++)
            {
                string[] operations = Console.ReadLine()
                    .Split(' ');

                string operation = operations[0];

                switch (operation)
                {
                    case "1":
                        int number = int.Parse(operations[1]);
                        numbers.Push(number);
                        break;
                    case "2":
                        if (numbers.Any())
                        numbers.Pop();
                        break;
                    case "3":
                        if (numbers.Any())
                        Console.WriteLine(numbers.Max());
                        break;
                    case "4":
                        if (numbers.Any())
                        Console.WriteLine(numbers.Min());
                        break;
                }

                //if (operation == "1")
                //{
                    //int number = int.Parse(operations[1]);

                    //numbers.Push(number);
                //}
                //else if (operation == "2" && numbers.Count > 0)
                //{
                        //numbers.Pop();                    
                //}
                //else if (operation == "3" && numbers.Count > 0)
                //{
                        //Console.WriteLine($"{numbers.Max()}");                    
                //}
                //else if (operation == "4" && numbers.Count > 0)
                //{                  
                        //Console.WriteLine($"{numbers.Min()}");                                   
                //}
            }

            if (numbers.Count > 0)
            {
                Console.WriteLine(string.Join(", ", numbers));
            }            
        }
    }
}
