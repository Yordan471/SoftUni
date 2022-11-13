using System;

namespace Activation_Keys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string rawActivationKey = Console.ReadLine();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Generate")
            {
                string[] commandToArray = command
                    .Split(">>>");

                string operation = commandToArray[0];

                if (operation == "Contains")
                {
                    string substring = commandToArray[1];

                    if (rawActivationKey.Contains(substring))
                    {
                        Console.WriteLine($"{rawActivationKey} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                else if (operation == "Flip")
                {
                    string upperOrLower = commandToArray[1];
                    int startIndex = int.Parse(commandToArray[2]);
                    int endIndex = int.Parse(commandToArray[3]);   
                    
                    string substring = rawActivationKey.Substring(startIndex, endIndex - startIndex);

                    if (upperOrLower == "Upper")
                    {
                        rawActivationKey = rawActivationKey.Replace(substring, substring.ToUpper());
                    }
                    else if (upperOrLower == "Lower")
                    {
                        rawActivationKey = rawActivationKey.Replace(substring, substring.ToLower());
                    }

                    Console.WriteLine(rawActivationKey);
                }
                else if (operation == "Slice")
                {
                    int startIndex = int.Parse(commandToArray[1]);
                    int endIndex = int.Parse(commandToArray[2]);

                    rawActivationKey = rawActivationKey.Remove(startIndex, endIndex - startIndex);

                    Console.WriteLine(rawActivationKey);
                }
            }

            Console.WriteLine($"Your activation key is: {rawActivationKey}");
        }
    }
}
