using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptSortAndPrintArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] encryptedNames = new int[n];

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();

                char[] nameToArray = name.ToCharArray();

                int sum = 0;

                for (int j = 0; j < nameToArray.Length; j++)
                {
                    int letter = nameToArray[j];

                    if (letter == 'a' || letter == 'e' || letter == 'i' || letter == 'o' || letter == 'u' ||
                        letter == 'A' || letter == 'E' || letter == 'I' || letter == 'O' || letter == 'U')
                    {
                        sum += letter * name.Length;
                    }
                    else
                    {
                        sum += letter / name.Length;
                    }
                }

                encryptedNames[i] = sum;
                sum = 0;
            }

            Array.Sort(encryptedNames);

            foreach (int name in encryptedNames)
            {
                Console.WriteLine(name);
            }
        }
    }
}
