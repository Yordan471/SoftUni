using System;
using System.Collections.Generic;

namespace The_Pianist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfPieces = int.Parse(Console.ReadLine());

            Dictionary<string, string> pieceComposerAndKey = new Dictionary<string, string>();

            for (int i = 0; i < numberOfPieces; i++)
            {
                string[] inputInfo = Console.ReadLine()
                    .Split('|');

                string piece = inputInfo[0];
                string composer = inputInfo[1];
                string key = inputInfo[2];

                string composerKey = composer + "-" + key;

                if (!pieceComposerAndKey.ContainsKey(piece))
                {
                    pieceComposerAndKey.Add(piece, composerKey);
                }
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] commandToArray = command
                    .Split('|');

                string operation = commandToArray[0];

                if (operation == "Add")
                {
                    string piece = commandToArray[1];
                    string composer = commandToArray[2];
                    string key = commandToArray[3];

                    string composerKey = composer + "-" + key;

                    if (!pieceComposerAndKey.ContainsKey(piece))
                    {
                        pieceComposerAndKey.Add(piece, composerKey);
                        Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                    }
                    else
                    {
                        Console.WriteLine($"{piece} is already in the collection!");
                    }
                }
                else if (operation == "Remove")
                {
                    string pieceToRemove = commandToArray[1];

                    if (pieceComposerAndKey.ContainsKey(pieceToRemove))
                    {
                        pieceComposerAndKey.Remove(pieceToRemove);
                        Console.WriteLine($"Successfully removed {pieceToRemove}!");
                    }
                    else
                    {
                    Console.WriteLine($"Invalid operation! {pieceToRemove} does not exist in the collection.");
                    }                
                }
                else if (operation == "ChangeKey")
                {
                    string piece = commandToArray[1];
                    string newKey = commandToArray[2];

                    if (pieceComposerAndKey.ContainsKey(piece))
                    {
                        string[] value = pieceComposerAndKey[piece].Split("-");
                        value[1] = newKey;

                        pieceComposerAndKey[piece] = string.Join("-", value);

                        Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }               
            }

            foreach (KeyValuePair<string, string> pieceComposer in pieceComposerAndKey)
            {
                Console.WriteLine($"{pieceComposer.Key} -> Composer: {pieceComposer.Value.Split('-')[0]}, Key: {pieceComposer.Value.Split('-')[1]}");
            }
        }
    }
}
