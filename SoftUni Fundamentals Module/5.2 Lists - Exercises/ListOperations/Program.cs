using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ListOperations
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
                string commands = Console.ReadLine();
                
                if (commands == "End")
                {
                    break;
                }

                List<string> listOfCommands = commands
                    .Split()
                    .ToList();
                List<int> saveNumbers = new List<int>();
                string operation = listOfCommands[0];
                int number = 0;
                int index = 0;

                if (listOfCommands.Count == 3)
                {
                    index = int.Parse(listOfCommands[2]);
                }

                if (operation == "Insert")
                {
                    number = int.Parse(listOfCommands[1]);

                    if (index < 0 || index > numbers.Count)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers.Insert(index, number);
                    }
            //        InsertNumber(numbers, number, index);
                }
                else if (operation == "Shift")
                {
                    string side = listOfCommands[1];

                    saveNumbers = new List<int>();

                    if (side == "left")
                    {
                        for (int i = 1; i <= index; i++)
                        {
                            for (int j = 0; j < numbers.Count; j++)
                            {
                                if (j == numbers.Count - 1)
                                {
                                    saveNumbers.Add(numbers[0]);
                                }
                                else
                                {
                                    saveNumbers.Add(numbers[j + 1]);
                                }
                            }

                            numbers = saveNumbers;
                            saveNumbers = new List<int>();
                        }
                    }
                    else
                    {
                        for (int i = 1; i <= index; i++)
                        {
                            for (int j = 0; j < numbers.Count; j++)
                            {
                                if (j == 0)
                                {
                                    saveNumbers.Add(numbers[numbers.Count - 1]);
                                }
                                else
                                {
                                    saveNumbers.Add(numbers[j - 1]);
                                }
                            }

                            numbers = saveNumbers;
                            saveNumbers = new List<int>();
                        }
                    }
                 //   ShiftNumbers(numbers, side, index, saveNumbers);
                }
                else if (operation == "Remove")
                {
                    index = int.Parse(listOfCommands[1]);

                    if (index < 0 || index > numbers.Count)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers.RemoveAt(index);
                    }
                }
                else if (operation == "Add")
                {
                    number = int.Parse(listOfCommands[1]);

                    numbers.Add(number);
                }
            }

            Console.WriteLine(String.Join(" ", numbers));
        }

   //    static List<int> InsertNumber(List<int> numbers, int number, int index)
   //    {
   //        if (index < 0 || index > numbers.Count)
   //        {
   //            return "Invalid index";
   //        }
   //        else
   //        {
   //            numbers.Insert(index, number);
   //        }
   //
   //        return numbers;
   //    }

    //    static List<int> ShiftNumbers(List<int> numbers, string side, int index, List<int> saveNumbers)
    //    {
    //        saveNumbers = new List<int>();
    //
    //        if (side == "left")
    //        {
    //            for (int i = 1; i <= index; i++)
    //            {
    //                for (int j = 0; j < numbers.Count; j++)
    //                {
    //                    if (j == numbers.Count - 1)
    //                    {
    //                        saveNumbers.Add(numbers[0]);
    //                    }
    //                    else
    //                    {
    //                        saveNumbers.Add(numbers[j + 1]);
    //                    }
    //                }
    //
    //                numbers = saveNumbers;
    //                saveNumbers = new List<int>();
    //            }
    //        }
    //        else
    //        {
    //            for (int i = 1; i <= index; i++)
    //            {
    //                for (int j = numbers.Count - 1; j >= 0; j++)
    //                {
    //                    saveNumbers.Add(numbers[j]);
    //                }
    //
    //                numbers = saveNumbers;
    //                saveNumbers = new List<int>();
    //            }
    //        }
    //        saveNumbers = numbers;
    //
    //        return numbers;
        
    }
}
