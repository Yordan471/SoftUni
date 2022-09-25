using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace KaminoFactory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lengthSequence = int.Parse(Console.ReadLine());

            int counterSequence = 0;
            int currentSequenceLength = 0;
            int sumOnes = 0;
            int saveBiggestSumOfOnes = 0;
            int saveBiggestSequenceLength = 0;
            int startingIndex = 0;
            int endingIndex = -1;
            int saveStartingIndex = 0;
            int dnaSample = 1;
            int saveDnaSample = 1;
            int[] saveSequence = new int[lengthSequence];

            while (true)
            {
                string command = Console.ReadLine();
                {
                    if (command == "Clone them!")
                    {
                        break;
                    }    
                }

                string[] separator = new string[] { "!" }; 

                int[] dnaSecuence = command
               .Split(separator, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

                counterSequence++;

                for (int i = 0; i < dnaSecuence.Length; i++)
                {
                    endingIndex++;

                    startingIndex = endingIndex - currentSequenceLength;

                    if (dnaSecuence[i] == 1)
                    {
                        currentSequenceLength++;
                        sumOnes += 1;
                    }

                    if (dnaSecuence[i] == 0 || i == dnaSecuence.Length - 1)
                    {
                        if (saveBiggestSequenceLength <= currentSequenceLength)
                        {
                            if (saveBiggestSequenceLength == currentSequenceLength && saveStartingIndex == startingIndex)
                            {
                                if (saveBiggestSumOfOnes < sumOnes)
                                {
                                    saveSequence = dnaSecuence;
                                    saveDnaSample = dnaSample;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            else if (saveBiggestSequenceLength == currentSequenceLength && saveStartingIndex > startingIndex)
                            {
                                saveSequence = dnaSecuence;
                                saveDnaSample = dnaSample;
                                saveBiggestSumOfOnes = sumOnes;
                                break;
                            }
                            else
                            {
                                saveBiggestSequenceLength = currentSequenceLength;
                                saveStartingIndex = endingIndex - saveBiggestSequenceLength;
                                saveSequence = dnaSecuence;
                                saveDnaSample = dnaSample;
                                saveBiggestSumOfOnes = sumOnes;
                            }
                        }
                    }                   

                    if (dnaSecuence[i] != 1)
                    {
                        currentSequenceLength = 0;
                    }

                    if (counterSequence == 1)
                    {
                        saveSequence = dnaSecuence;
                        saveBiggestSumOfOnes = sumOnes;
                    }
                }

                dnaSample++;
                endingIndex = -1;
                sumOnes = 0;
                currentSequenceLength = 0;
            }

            Console.WriteLine($"Best DNA sample {saveDnaSample} with sum: {saveBiggestSumOfOnes}.");

            foreach (int dna in saveSequence)
            {
                Console.Write(dna + " ");
            }
        }
    }
}
