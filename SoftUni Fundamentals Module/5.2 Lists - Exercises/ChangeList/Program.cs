using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                List<string> operations = command.Split().ToList();

                string operation = operations[0];
                int number = 0;
                int index = 0;

                switch (operation)
                {
                    case "Delete":
                        DeleteAllPointedNumbers(numbers, number, operations);
                        break;
                    case "Insert":
                        InsertNumber(numbers, index, number, operations);
                        break;
                }
            }

            Console.WriteLine(String.Join(" ", numbers));
        }

        static List<int> DeleteAllPointedNumbers(List<int> numbers, int number, List<string> operations)
        {
            number = int.Parse(operations[1]);

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == number)
                {
                    numbers.RemoveAt(i);
                    i--;
                }
            }

            return numbers;
        }

        static List<int> InsertNumber(List<int> numbers, int index, int number, List<string> operations)
        {
            number = int.Parse(operations[1]);
            index = int.Parse(operations[2]);

            numbers.Insert(index, number);

            return numbers;
        }
    }
}
