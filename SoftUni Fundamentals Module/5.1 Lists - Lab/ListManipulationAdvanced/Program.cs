using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ListManipulationAdvanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> saveNumbers = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                saveNumbers.Add(numbers[i]);
            }

            string command = Console.ReadLine();

            while (command != "end")
            {
                List<string> listOperations = command.Split().ToList();

                string operation = listOperations[0];
                int number = 0;
                int index = 0;
                int numberTask = 0;
                string condition = string.Empty;

                if (listOperations.Count == 2)
                {
                    number = int.Parse(listOperations[1]);
                    numberTask = number;
                }
                else if (listOperations.Count == 3)
                {
                    index = int.Parse(listOperations[2]);
                    number = int.Parse(listOperations[2]);
                    condition = listOperations[1];
                }

                if (operation == "Insert")
                {
                    numberTask = int.Parse(listOperations[1]);
                }

                switch (operation)
                {
                    case "Contains":
                        CheckIfNumberIsIn(numbers, command, number);
                        break;
                    case "PrintEven":
                        PrintEvenNumbers(numbers);                        
                        break;
                    case "PrintOdd":
                        PrintOddNumbers(numbers);
                        break;
                    case "GetSum":
                        PrintSumOfNumbers(numbers);
                        break;
                    case "Filter":
                        PrintFilterNumbers(numbers, condition, number);
                        break;
                }

                CommandsFromThePreviousTask(numbers, operation, numberTask, index);

                command = Console.ReadLine();
            }

            bool notEqual = false;
            
            for (int i = 0; i < Math.Max(numbers.Count, saveNumbers.Count); i++)
            {
                if (numbers.Count > saveNumbers.Count || saveNumbers.Count > numbers.Count)
                {
                    notEqual = true;
                    break;
                }
          
                if (numbers[i] != saveNumbers[i])
                {
                    notEqual = true;
                    break;
                }
            }
            
            if (notEqual)
            {
                Console.WriteLine(String.Join(" ", numbers));
            }
        }

        static void CheckIfNumberIsIn(List<int> numbers, string command, int number)
        {
            if (numbers.Contains(number) == true)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No such number");
            }      
        }

        static void PrintEvenNumbers(List<int> numbers)
        {
            List<int> returnEvenNumbers = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    returnEvenNumbers.Add(numbers[i]);
                }
            }

            Console.WriteLine(String.Join(" ", returnEvenNumbers));
        }

        static void PrintOddNumbers(List<int> numbers)
        {
            List<int> returnOddNumbers = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] % 2 != 0)
                {
                    returnOddNumbers.Add(numbers[i]);
                }
            }

            Console.WriteLine(String.Join(" ", returnOddNumbers));
        }

        static void PrintSumOfNumbers(List<int> numbers)
        {
            long sumNumbers = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                sumNumbers += numbers[i];
            }

            Console.WriteLine(sumNumbers);
        }

        static void PrintFilterNumbers(List<int> numbers, string condition, int number)
        {
            List<int> filteredNumbers = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (condition == "<")
                {
                    if (numbers[i] < number)
                    {
                        filteredNumbers.Add(numbers[i]);
                    }
                }
                else if (condition == ">")
                {
                    if (numbers[i] > number)
                    {
                        filteredNumbers.Add(numbers[i]);
                    }
                }
                else if (condition == ">=")
                {
                    if (numbers[i] >= number)
                    {
                        filteredNumbers.Add(numbers[i]);
                    }
                }
                else if (condition == "<=")
                {
                    if (numbers[i] <= number)
                    {
                        filteredNumbers.Add(numbers[i]);
                    }
                }
            }
           
            Console.WriteLine(String.Join(" ", filteredNumbers));
        }

        static List<int> CommandsFromThePreviousTask(List<int> numbers, string operation, int number, int index)
        {
            switch (operation)
            {
                case "Add":
                    numbers.Add(number);
                    break;
                case "Remove":
                    numbers.Remove(number);
                    break;
                case "RemoveAt":
                    numbers.RemoveAt(number);
                    break;
                case "Insert":
                    numbers.Insert(index, number);
                    break;
            }

            return numbers;
        }
    }
}
