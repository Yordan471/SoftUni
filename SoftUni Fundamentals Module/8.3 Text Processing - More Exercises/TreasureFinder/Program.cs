using System;
using System.Collections.Generic;
using System.Linq;

namespace TreasureFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] key = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

            List<string> gatherDecryptedSeq = new List<string>();
            List<string> arrangedSequences = new List<string>();
            string decryptedSequence = string.Empty;
            string command = string.Empty;
            int counter = 0;

            while ((command = Console.ReadLine()) != "find")
            {
                for (int i = 0; i < command.Length; i++)
                {
                    if (counter == key.Length)
                    {
                        counter = 0;
                    }

                    decryptedSequence += (char)(command[i] - key[counter]);
                    counter++;
                }

                gatherDecryptedSeq.Add(decryptedSequence);
                decryptedSequence = string.Empty;
                counter = 0;
            }

            for (int i = 0; i < gatherDecryptedSeq.Count; i++)
            {
                int firstSymbolFirst = gatherDecryptedSeq[i].IndexOf('&');
                int firstSymbolLast = gatherDecryptedSeq[i].LastIndexOf('&');
                int typeLength = firstSymbolLast - firstSymbolFirst;

                int secondSymbolStart = gatherDecryptedSeq[i].IndexOf('<');
                int secondSymbolEnd = gatherDecryptedSeq[i].IndexOf('>');
                int coordinatesLength = secondSymbolEnd - secondSymbolStart;

                string type = gatherDecryptedSeq[i].Substring(firstSymbolFirst + 1, typeLength - 1);
                string coordinates = gatherDecryptedSeq[i].Substring(secondSymbolStart + 1, coordinatesLength - 1);

                arrangedSequences.Add($"Found {type} at {coordinates}");
            }

            Console.WriteLine(string.Join(Environment.NewLine, arrangedSequences));
        }
    }
}
