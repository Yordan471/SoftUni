using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Count_Uppercase_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<string> isCapitalFirstLetter = 
                (string x) => x.Length > 0 && char.IsUpper(x[0]);

            Console.WriteLine(string.Join(Environment.NewLine, Console.ReadLine()
                .Split(' ')
                .Where(x =>isCapitalFirstLetter(x))
                .ToArray()));
        }
    }
}
