using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anonymous
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> inputLine = Console.ReadLine()
                .Split()
                .ToList();
            string command = Console.ReadLine();

            while (true)
            {
                if (command == "3:1")
                {
                    break;
                }

                List<string> commandToList = command
                    .Split()
                    .ToList();

                string operation = commandToList[0];

                if (operation == "merge")
                {
                    int startIndex = int.Parse(commandToList[1]);
                    int endIndex = int.Parse(commandToList[2]);

                    if ((startIndex >= 0 && startIndex < inputLine.Count) && 
                        (endIndex >= 0 && endIndex < inputLine.Count))
                    {
                        for (int i = startIndex; i < endIndex; i++)
                        {
                            inputLine[startIndex] += inputLine[i + 1];
                            inputLine.RemoveAt(i + 1);
                            i--;
                            endIndex--;
                        }                 
                    }
                    else if ((startIndex < 0 || startIndex > inputLine.Count) && 
                        endIndex >= 0 && endIndex < inputLine.Count)
                    {
                        for (int i = 0; i <= endIndex; i++)
                        {
                            inputLine[0] += inputLine[i + 1];
                            inputLine.RemoveAt(i + 1);
                        }
                    }
                    else if ((endIndex < 0 || endIndex >= inputLine.Count) && 
                        startIndex >= 0 && startIndex < inputLine.Count)
                    {
                        for (int i = startIndex; i <= inputLine.Count; i++)
                        {
                            if (i + 1 >= inputLine.Count)
                            {
                                break;
                            }

                            inputLine[startIndex] += inputLine[i + 1];
                            inputLine.RemoveAt(i + 1);
                            i--;
                        }
                        
                    }
                    
                }
                else if (operation == "divide")
                {
                    int index = int.Parse(commandToList[1]);
                    int partitions = int.Parse(commandToList[2]);

                    string saveIndexElement = inputLine[index];
                    inputLine.RemoveAt(index);
                    int partSizq = saveIndexElement.Length / partitions;
                    int reminderOfIndexElement = saveIndexElement.Length % partitions;

                    List<string> savePartsOfElement = new List<string>();

                    for (int i = 0; i < partitions; i++)
                    {
                        string part = string.Empty;

                        for (int j = 0; j < partSizq; j++)
                        {
                            part += saveIndexElement[(i * partSizq) + j];
                        }

                        if (i == partitions - 1 && reminderOfIndexElement != 0)
                        {
                            part += saveIndexElement.Substring(saveIndexElement.Length - reminderOfIndexElement);
                        }

                        savePartsOfElement.Add(part);
                    }

                    inputLine.InsertRange(index, savePartsOfElement);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(String.Join(" ", inputLine));
        }
    }
}
