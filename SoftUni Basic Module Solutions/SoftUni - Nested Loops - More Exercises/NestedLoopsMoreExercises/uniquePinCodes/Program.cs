using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uniquePinCodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            for (int i = 2; i <= num1; i += 2)
            {
                for (int j = 2; j <= num2; j++)
                {
                    for (int k = 2; k <= num3; k += 2)
                    {
                        if (j == 2 || j == 3 || j == 5 || j == 7)
                        {
                            Console.WriteLine(i + " " + j + " " + k);
                        }
                    }
                }
            }
        }
    }
}
