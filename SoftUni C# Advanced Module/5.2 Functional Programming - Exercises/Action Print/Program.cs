using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Action_Print
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries);
           
            Action<string[]> print = name => 
            Console.WriteLine(string.Join(Environment.NewLine, names));

            print(names);
        }
    }
}
