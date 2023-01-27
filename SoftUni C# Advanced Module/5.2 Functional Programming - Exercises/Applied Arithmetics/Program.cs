using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applied_Arithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<List<int>, string, List<int>> operations =
               (numberss, operation) =>
               {
                   List<int> result = new List<int>();

                   foreach (int number in numberss)
                   {
                       switch (operation)
                       {
                           case "add":
                               result.Add(number + 1);
                               break;
                           case "multiply":
                               result.Add(number * 2);
                               break;
                           case "subtract":
                               result.Add(number - 1);
                               break;
                       }
                   }

                   return result;
               };

            List<int> numbers = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(number => int.Parse(number))
                .ToList();

            Action<List<int>> print = numberss => Console.WriteLine(string.Join(" ", numbers)); ;
              
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "print")
                {
                    print(numbers);
                }
                else
                {
                    numbers = operations(numbers, command);
                }
            }         
        }
    }
}
