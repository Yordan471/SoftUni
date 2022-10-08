using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> sequenceOfElements = Console.ReadLine()
                .Split(' ')
                .ToList();

            string command = Console.ReadLine();
            int movesCounter = 0;
            bool end = false;
            bool won = false;

            while (true)
            {
                if (command == "end")
                {
                    end = true;
                    break;
                }

                List<string> inputIndexes = command
                    .Split()
                    .ToList();

                int firstIndex = int.Parse(inputIndexes[0]);
                int secondIndex = int.Parse(inputIndexes[1]);

                movesCounter++;
 
                if (firstIndex == secondIndex || (!(firstIndex >= 0 && firstIndex < sequenceOfElements.Count - 1) ||
                    !(secondIndex >= 0 && secondIndex <= sequenceOfElements.Count - 1)))
                {
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                    string sMovesCounter = "-" + movesCounter + "a";
                    if (sequenceOfElements.Count % 2 == 0)
                    {
                        sequenceOfElements.Insert((sequenceOfElements.Count / 2), sMovesCounter);
                        sequenceOfElements.Insert((sequenceOfElements.Count / 2), sMovesCounter);
                    }
                    else
                    {
                        sequenceOfElements.Insert((sequenceOfElements.Count / 2 + 1), sMovesCounter);
                        sequenceOfElements.Insert((sequenceOfElements.Count / 2 + 1), sMovesCounter);
                    }
                }

                else if (sequenceOfElements[firstIndex] == sequenceOfElements[secondIndex])
                {
                    Console.WriteLine($"Congrats! You have found matching elements - {sequenceOfElements[firstIndex]}!");

                    if (firstIndex < secondIndex)
                    {
                        sequenceOfElements.RemoveAt(firstIndex);
                        sequenceOfElements.RemoveAt(secondIndex - 1);
                    }   
                    else
                    {
                        sequenceOfElements.RemoveAt(firstIndex);
                        sequenceOfElements.RemoveAt(secondIndex);
                    }
                }
                else if (sequenceOfElements[firstIndex] != sequenceOfElements[secondIndex])
                {
                    Console.WriteLine("Try again!");
                }


                if (sequenceOfElements.Count == 0)
                {
                    Console.WriteLine($"You have won in {movesCounter} turns!");
                    won = true;
                    break;
                }

                command = Console.ReadLine();
            }

            if (end && won == false)
            {
                Console.WriteLine("Sorry you lose :(");
                Console.WriteLine(string.Join(" ", sequenceOfElements));
            }
        }
    }
}
