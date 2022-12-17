using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Traffic_Jam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int carsToPass = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();
            int passedCars = 0;

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                string carOrGreen = command;

                if (carOrGreen != "green")
                {
                    cars.Enqueue(carOrGreen);
                }
                else if (carOrGreen == "green" && cars.Count > 0)
                {               
                    int carsCount = cars.Count;

                    while (cars.Count != carsCount - carsToPass && cars.Count != 0)
                    {
                        Console.WriteLine($"{cars.Dequeue()} passed!");
                        passedCars++;
                    }
                }
            }

            Console.WriteLine($"{passedCars} cars passed the crossroads.");
        }
    }
}
