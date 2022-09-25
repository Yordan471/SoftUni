using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestIncreasingSubsequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

            int[] solutions = new int[array.Length];
            int[] prev = new int[array.Length];
            int maxSolution = 0;
            int maxSolutionIndex = 0;

            for (int current = 0; current < array.Length; current++)
            {
                // when we have only one solution
                int solution = 1;
                int prevIndex = -1;
                int currentNumber = array[current];
                
                for (int solutionIndex = 0; solutionIndex < current; solutionIndex++)
                {
                    int prevNumber = array[solutionIndex];
                    int prevSolution = solutions[solutionIndex];
                    
                    if (currentNumber > prevNumber && solution <= prevSolution)
                    {
                        solution = prevSolution + 1;
                        prevIndex = solutionIndex;
                    }
                }

                solutions[current] = solution;
                prev[current] = prevIndex;

                if (solution >= maxSolution)
                {
                    maxSolution = solution;
                    maxSolutionIndex = current;
                }
            }

            int index = maxSolutionIndex;

            var result = new List<int>();

            while (index != -1)
            {
                int currentNumber = array[index];
                result.Add(currentNumber);
                index = prev[index];
            }

            result.Reverse();

            Console.WriteLine(String.Join(" ", result));
        }
    }
}
