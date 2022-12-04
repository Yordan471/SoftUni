using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace Decrypting_Commands
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string cryptedCommands = Console.ReadLine();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Finish")
            {
                string[] commandToArray = command
                    .Split(' ');

                string operation = commandToArray[0];

                if (operation == "Replace")
                {
                    string currChar = commandToArray[1];
                    string newChar = commandToArray[2];

                    if (cryptedCommands.Contains(currChar))
                    {
                        cryptedCommands = cryptedCommands.Replace(currChar, newChar);
                        Console.WriteLine(cryptedCommands);
                    }
                }
                else if (operation == "Cut")
                {
                    int startIndex = int.Parse(commandToArray[1]);
                    int endIndex = int.Parse(commandToArray[2]);
                    int lengthToRemove = endIndex - startIndex;

                    if ((startIndex >= 0 && startIndex <= cryptedCommands.Length - 1) &&
                           (endIndex >= 0 && endIndex <= cryptedCommands.Length - 1))
                    {
                        cryptedCommands = cryptedCommands.Remove(startIndex, lengthToRemove + 1);
                        Console.WriteLine(cryptedCommands);
                    }
                    else
                    {
                        Console.WriteLine("Invalid indices!");
                    }
                }
                else if (operation == "Make")
                {
                    if (commandToArray[1] == "Upper")
                    {
                        cryptedCommands = cryptedCommands.ToUpper();
                        Console.WriteLine(cryptedCommands);
                    }
                    else
                    {
                        cryptedCommands = cryptedCommands.ToLower();
                        Console.WriteLine(cryptedCommands);
                    }
                }
                else if (operation == "Check")
                {
                    string substring = commandToArray[1];

                    if (cryptedCommands.Contains(substring))
                    {
                        Console.WriteLine($"Message contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine($"Message doesn't contain {substring}");
                    }
                }
                else if (operation == "Sum")
                {
                    int startIndex = int.Parse(commandToArray[1]);
                    int endIndex = int.Parse(commandToArray[2]);
                    int stringLength = endIndex - startIndex;
                   
                    if ((startIndex >= 0 && startIndex <= cryptedCommands.Length - 1) &&
                           (endIndex >= 0 && endIndex <= cryptedCommands.Length - 1))
                    {
                        string substring = cryptedCommands.Substring(startIndex, stringLength + 1);

                        char[] chars = substring.ToCharArray();
                        int sumChars = 0;

                        for (int i = 0; i < chars.Length; i++)
                        {
                            int charToInt = chars[i];
                            sumChars += charToInt;
                        }

                        Console.WriteLine(sumChars);
                    }
                    else
                    {
                        Console.WriteLine("Invalid indices!");
                    }
                }               
            }
        }
    }
}
