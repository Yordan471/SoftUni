using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MergingLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstListNumbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> secondListNumbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> MergingList = new List<int>();
            int counter = -1;

            for (int i = 0; i < Math.Min(firstListNumbers.Count, secondListNumbers.Count); i++)
            {
                counter++;
      
                 MergingList.Add(firstListNumbers[0 + i]);
                 MergingList.Add(secondListNumbers[0 + i]);                                                                       
            }
      
            for (int i = 0; i < Math.Max(firstListNumbers.Count, secondListNumbers.Count) - counter - 1; i++)
            {
                if (firstListNumbers.Count > secondListNumbers.Count)
                {
                    MergingList.Add(firstListNumbers[counter + 1 + i]);
                }
                else
                {
                    MergingList.Add(secondListNumbers[counter + 1 + i]);
                }
            }
      
            Console.WriteLine(String.Join(" ", MergingList));         
        }
    }
}
