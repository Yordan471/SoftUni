using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Record_Unique_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfNames = int.Parse(Console.ReadLine());

            HashSet<string> set = new HashSet<string>();

            for (int i = 0; i < numberOfNames; i++)
            {
                set.Add(Console.ReadLine());
            }

            Console.WriteLine(string.Join(Environment.NewLine, set));
        }
    }
}
