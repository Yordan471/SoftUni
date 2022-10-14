using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonDontGo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = "something";
            string partOfWord = string.Empty;

            partOfWord = word.Substring(2);
            Console.WriteLine(partOfWord);
        }
    }
}
