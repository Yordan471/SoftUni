using System;
using System.Text;

namespace Password_Reset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Done")
            {
                string[] commandToArray = command
                    .Split(' ');

                string operation = commandToArray[0];

                if (operation == "TakeOdd")
                {
                    StringBuilder rawPassword = new StringBuilder();

                    for (int i = 1; i < inputString.Length; i += 2)
                    {
                        rawPassword.Append(inputString[i]);
                    }

                    inputString = rawPassword.ToString();

                    Console.WriteLine(inputString);
                }
                else if (operation == "Cut")
                {
                    int index = int.Parse(commandToArray[1]);
                    int length = int.Parse(commandToArray[2]);

                    inputString = inputString.Remove(index, length);
                    Console.WriteLine(inputString);
                }
                else if (operation == "Substitute")
                {
                    string substring = commandToArray[1];
                    string substitute = commandToArray[2];

                    if (inputString.Contains(substring))
                    {
                        inputString = inputString.Replace(substring, substitute);
                        Console.WriteLine(inputString);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace");
                    }
                }                   
            }

            Console.WriteLine($"Your password is: {inputString}");
        }
    }
}
