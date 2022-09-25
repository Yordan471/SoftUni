using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            bool itsBigger = false;
            bool itsLastIndex = false;

            for (int i = 0; i < array.Length; i++)
            {
                if (i == array.Length - 1)
                {
                    itsLastIndex = true;
                }

                for (int j = 1 + i; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        itsBigger = true;
                        continue;
                    }
                    else
                    {
                        itsBigger = false;
                        break;
                    }
                }

                if (itsLastIndex)
                {
                    Console.Write(array[i] + " ");
                    break;
                }
                else if (itsBigger)
                {
                    Console.Write(array[i] + " ");
                }
            }
        }
    }
}
