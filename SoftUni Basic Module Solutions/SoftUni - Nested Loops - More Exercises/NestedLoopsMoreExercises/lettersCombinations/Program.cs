using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lettersCombinations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char letter1 = char.Parse(Console.ReadLine());
            char letter2 = char.Parse(Console.ReadLine());
            char letter3 = char.Parse(Console.ReadLine());

            int counter = 0;

            for (char i = letter1; i <= letter2; i++)
            {
                for (char j = letter1; j <= letter2; j++)
                {             
                    for (char k = letter1; k <= letter2; k++)
                    {

                    if (i == letter3 || j == letter3 || k == letter3)
                        {
                            continue;
                        }

                    else
                        {
                            counter++;
                            Console.Write($"{i}{j}{k} ");
                        }
                    }                 
                }                    
            }
            Console.WriteLine(counter);
        }
    }
}
