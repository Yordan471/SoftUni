using System;
using System.Data;
using System.Linq;

namespace Secret_Chat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string encryptedMessage = Console.ReadLine();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Reveal")
            {
                string[] commandToArray = command
                    .Split(":|:");

                string operation = commandToArray[0];

                if (operation == "InsertSpace")
                {
                    int index = int.Parse(commandToArray[1]);

                    encryptedMessage = encryptedMessage.Insert(index, " ");

                    Console.WriteLine(encryptedMessage);
                }
                else if (operation == "Reverse")
                {
                    string substring = commandToArray[1];
                    
                    if (encryptedMessage.Contains(substring))
                    {
                        int index = encryptedMessage.IndexOf(substring);

                        encryptedMessage = encryptedMessage.Remove(index, substring.Length);
                        
                        char[] chars = substring.ToCharArray();
                        Array.Reverse(chars);

                        string reversed = string.Empty;

                        foreach (char ch in chars)
                        {
                            reversed += ch;  
                        }

                        encryptedMessage += reversed;

                        Console.WriteLine(encryptedMessage);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }                   
                }
                else if (operation == "ChangeAll")
                {
                    string substring = commandToArray[1];
                    string replacement = commandToArray[2];

                    if (encryptedMessage.Contains(substring))
                    {
                        int index = encryptedMessage.IndexOf(substring);

                        while (encryptedMessage.Contains(substring))
                        {
                            encryptedMessage = encryptedMessage.Replace(substring, replacement);
                        }
                    }

                    Console.WriteLine(encryptedMessage);
                }
            }

            Console.WriteLine($"You have a new text message: {encryptedMessage}");
        }
    }
}
