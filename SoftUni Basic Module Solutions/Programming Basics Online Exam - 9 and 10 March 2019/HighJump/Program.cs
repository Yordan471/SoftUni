using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighJump
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int wantedHigh = int.Parse(Console.ReadLine());

            int less30 = 30;
            int highLess30 = wantedHigh - 30;
            int add5sm = 5;
            int counterFailed3Times = 0;
            int counterJumps = 0;
            int saveHighLess30 = 0;
            int jumpHighed = 0;
            bool failed = false;
            bool win = false;

            while (true)
            {
                jumpHighed = int.Parse(Console.ReadLine());

                counterJumps++;

                if (jumpHighed > highLess30)
                {
                    highLess30 += add5sm;
                }
                else
                {
                    if (saveHighLess30 != highLess30)
                    {
                        counterFailed3Times = 0;
                    }

                    saveHighLess30 = highLess30;
                    counterFailed3Times++;
                }

                if (highLess30 > wantedHigh)
                {
                    highLess30 -= add5sm;
                    win = true;
                    break;
                }

                if (counterFailed3Times == 3)
                {
                    failed = true;
                    break;
                }
            }   
            
            if (failed)
            {
                Console.WriteLine($"Tihomir failed at {saveHighLess30}cm after {counterJumps} jumps.");
            }
            else if (win)
            {
                Console.WriteLine($"Tihomir succeeded, he jumped over {highLess30}cm after {counterJumps} jumps.");
            }
        }
    }
}
