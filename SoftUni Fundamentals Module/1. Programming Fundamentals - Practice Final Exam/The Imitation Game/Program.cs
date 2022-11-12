using System;

namespace The_Imitation_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string encryptedMessage = Console.ReadLine();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Decode")
            {
                string[] commandToArray = command
                    .Split('|');

                string operation = commandToArray[0];

                if (operation == "Move")
                {
                    int numberOfLetters = int.Parse(commandToArray[1]);

                    string moveLetters = encryptedMessage.Substring(0, numberOfLetters);
                    encryptedMessage = encryptedMessage.Remove(0, numberOfLetters);
                    encryptedMessage += moveLetters;
                }
                else if (operation == "Insert")
                {
                    int index = int.Parse(commandToArray[1]);
                    string value = commandToArray[2];

                    encryptedMessage = encryptedMessage.Insert(index, value);
                }
                else if (operation == "ChangeAll")
                {
                    string substring = commandToArray[1];
                    string replacement = commandToArray[2];

                    encryptedMessage = encryptedMessage.Replace(substring, replacement);
                }
            }

            Console.WriteLine($"The decrypted message is: {encryptedMessage}");
        }
    }
}
