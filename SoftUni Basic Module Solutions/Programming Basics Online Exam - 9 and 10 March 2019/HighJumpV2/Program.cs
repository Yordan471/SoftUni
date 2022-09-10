using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighJumpV2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int wantedHeight = int.Parse(Console.ReadLine());

            int heightLess30 = 30;
            int add5cm = 5;
            double heightWithLess30 = wantedHeight - heightLess30;

            while (true)
            {

                for (int i = 1; i < 3; i++)
                {
                    int jumpHeight = int.Parse(Console.ReadLine());
                    
                    if (jumpHeight > heightWithLess30)
                    {
                        heightWithLess30 += add5cm;
                        i = 1;
                    }

                    if (heightWithLess30 > wantedHeight)
                    {
                        break;
                    }
                }
            }
        }
    }
}
