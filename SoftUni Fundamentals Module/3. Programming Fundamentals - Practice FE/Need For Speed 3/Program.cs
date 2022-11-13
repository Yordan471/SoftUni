using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

namespace Need_For_Speed_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());

            Dictionary <string, int> carAndDistance = new Dictionary<string, int>();
            Dictionary <string, int> carAndFuel = new Dictionary<string, int>();

            for (int i = 0; i < numberOfCars; i++)
            {
                string command = Console.ReadLine();

                string[] commandToArray = command
                    .Split('|');

                string car = commandToArray[0];
                int distance = int.Parse(commandToArray[1]);
                int fuel = int.Parse(commandToArray[2]);

                carAndDistance[car] = distance;
                carAndFuel[car] = fuel;
                
            }

            string inputArgs = string.Empty;

            while ((inputArgs = Console.ReadLine()) != "Stop")
            {
                string[] inputArgsArray = inputArgs
                    .Split(" : ");

                string operation = inputArgsArray[0];
                string car = inputArgsArray[1];
                
                if (operation == "Drive")
                {
                    int endMileage = 100000;
                    int distance = int.Parse(inputArgsArray[2]);
                    int fuel = int.Parse(inputArgsArray[3]);

                    if (fuel > carAndFuel[car])
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                    else
                    {
                        carAndDistance[car] += distance;
                        carAndFuel[car] -= fuel;
                        Console.WriteLine($"{car} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                    }

                    if (carAndDistance[car] >= endMileage)
                    {
                        carAndDistance.Remove(car);
                        carAndFuel.Remove(car);

                        Console.WriteLine($"Time to sell the {car}!");
                    }
                }
                else if (operation == "Refuel")
                {
                    int fuel = int.Parse(inputArgsArray[2]);
                    int litersLeft = 0;

                    if (carAndFuel[car] + fuel <= 75)
                    {
                        carAndFuel[car] += fuel;
                        litersLeft = fuel;
                    }
                    else
                    {
                        litersLeft = carAndFuel[car] + fuel - 75;
                        litersLeft = fuel - litersLeft;
                        carAndFuel[car] = 75;
                    }

                    Console.WriteLine($"{car} refueled with {litersLeft} liters");
                }
                else if (operation == "Revert")
                {
                    int kilometers = int.Parse(inputArgsArray[2]);

                    if (carAndDistance[car] - kilometers < 10000)
                    {
                        carAndDistance[car] = 10000;
                    }
                    else
                    {
                        carAndDistance[car] -= kilometers;
                        Console.WriteLine($"{car} mileage decreased by {kilometers} kilometers");
                    }
                }
            }

            //"{car} -> Mileage: {mileage} kms, Fuel in the tank: {fuel} lt."

            foreach (var carDistance in carAndDistance)
            {
                foreach (var carFuel in carAndFuel)
                {
                    if (carFuel.Key == carDistance.Key)
                    {          
                        Console.WriteLine($"{carFuel.Key} -> Mileage: {carDistance.Value} kms, Fuel in the tank: {carFuel.Value} lt.");
                        break;
                    }
                }
            }
        }
    }
}
