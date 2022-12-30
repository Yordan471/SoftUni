using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] setsLength = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            HashSet<int> set = new HashSet<int>();
            HashSet<int> saveNumbers = new HashSet<int>();

            int firstSetLength = setsLength[0];
            int secondSetLength = setsLength[1];

            
        }
    }
}
