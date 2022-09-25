using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayRotation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int rotations = int.Parse(Console.ReadLine());

            int[] newArray = new int[array.Length];

            for (int i = 0; i < rotations; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    if (j == array.Length - 1)
                    {
                        newArray[j] = array[0];
                        array = newArray;
                        newArray = new int[array.Length];
                        break;
                    }

                    newArray[j] = array[j + 1];
                }
            }

            foreach (int arr in array)
            {
                Console.Write(arr + " ");
            }
        }
    }
}
