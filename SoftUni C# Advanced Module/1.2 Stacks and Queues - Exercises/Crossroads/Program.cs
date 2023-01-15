using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int durationGreenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();

            string command = string.Empty;
            int carsPassed = 0;

            while ((command = Console.ReadLine()) != "END")
            {
                bool crashHappened = false;

                if (command != "green")
                {
                    cars.Enqueue(command);
                }
                else
                {
                    int durationLeft = durationGreenLight;
                    bool durationLeftNegative = false;

                    while (!durationLeftNegative && cars.Count > 0) 
                    {
                        char[] car = cars.Peek().ToCharArray();
                        
                        if (durationLeft - car.Length > 0)
                        {
                            durationLeft -= car.Length;
                 
                            cars.Dequeue();
                            carsPassed++;
                        }
                        else
                        {
                            int charsLeft = car.Length - durationLeft;
                            durationLeftNegative = true;

                            if (freeWindow - charsLeft >= 0)
                            {
                                cars.Dequeue();
                                carsPassed++;
                            }
                            else
                            {
                                char crashAtChar = car[car.Length -(car.Length - durationLeft - freeWindow)];

                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{cars.Peek()} was hit at {crashAtChar}.");
                                crashHappened = true;
                                break;                         
                            }
                        }
                    }
                }

                if (crashHappened)
                {
                    return;
                }
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{carsPassed} total cars passed the crossroads.");
        }
    }
}
