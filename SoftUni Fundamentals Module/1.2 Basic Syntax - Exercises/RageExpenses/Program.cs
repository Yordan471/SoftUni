using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RageExpenses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //every second lost game - headset
            //every third lost game - moues]
            //when headset and mouse in the same lost game - keyboard
            //every second trash of a keyboard - display

            int lostGames = int.Parse(Console.ReadLine());
            double priceForHeadset = double.Parse(Console.ReadLine());
            double priceForMouse = double.Parse(Console.ReadLine());
            double priceForKeyboard = double.Parse(Console.ReadLine());
            double priceForDisplay = double.Parse(Console.ReadLine());

            int counter = 0;
            double sum = 0;
            int counterKeyboard = 0;


            for (int i = 1; i <= lostGames; i++)
            {
                counter++;

                if (counter % 2 == 0)
                {
                    sum += priceForHeadset;
                }

                if (counter % 3 == 0)
                {
                    sum += priceForMouse;
                }

                if (counter % 2 == 0 && counter % 3 == 0)
                {
                    counterKeyboard++;
                    sum += priceForKeyboard;
                }

                if (counterKeyboard % 2 == 0 && counterKeyboard != 0)
                {
                    counterKeyboard = 0;
                    sum += priceForDisplay;
                }
            }

            Console.WriteLine($"Rage expenses: {sum:f2} lv.");
        }
    }
}
