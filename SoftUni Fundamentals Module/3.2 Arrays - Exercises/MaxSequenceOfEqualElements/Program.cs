using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxSequenceOfEqualElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int[] saveArray = new int[array.Length];
            int saveSequenceLength = 0;
            int sequenceLength = 0;

            for (int i = 0; i < array.Length; i++)
            {

                for (int j = i + 1; j < array.Length; j++)
                {                  
                    if (array[i] == array[j])
                    {
                        sequenceLength++;
                    }
                    else
                    {
                        break;
                    }         
                }

                if (saveSequenceLength < sequenceLength)
                {
                    saveSequenceLength = sequenceLength;
                    saveArray = new int[saveSequenceLength + 1];

                    for (int k = 0; k < saveArray.Length; k++)
                    {
                        saveArray[k] += array[i];
                    }
                }

                sequenceLength = 0;
            }

            foreach (int arr in saveArray)
            {
                Console.Write(arr + " "); 
            }
        }
    }
}
