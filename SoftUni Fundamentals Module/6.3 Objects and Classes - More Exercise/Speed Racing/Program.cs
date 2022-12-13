using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speed_Racing
{
    public class Program
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            AddingCarsToAList(numberOfCars, cars);

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandsInfo = command
                    .Split();

                string model = commandsInfo[1];
                double distance = double.Parse(commandsInfo[2]);

                Car car = cars.First(c => c.Model == model);

                Car.CHechIfThereIsEnoughFuel(distance, car);
            }

            PrintingResult(cars);
        }

        private static void PrintingResult(List<Car> cars)
        {
            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TraveledDistance}");
            }
        }

        private static void AddingCarsToAList(int numberOfCars, List<Car> cars)
        {
            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split();

                string model = carInfo[0];
                double fuelAmount = double.Parse(carInfo[1]);
                double fuelConsumption = double.Parse(carInfo[2]);
                double traveledDistance = 0;

                Car car = new Car(model, fuelAmount, fuelConsumption, traveledDistance);

                cars.Add(car);
            }
        }
    }

    public class Car
    {

        public Car(string model, double fuelAmount, double fuelConsumption, double traveledDistance)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumption = fuelConsumption;
            TraveledDistance = traveledDistance;
        }

        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsumption { get; set; }

        public double TraveledDistance { get; set; }

        public static void CHechIfThereIsEnoughFuel(double distance, Car car)
        {
            double fuelNeeded = car.FuelConsumption * distance;

            if (fuelNeeded > car.FuelAmount)
            {
                Console.WriteLine($"Insufficient fuel for the drive");
            }
            else
            {
                car.FuelAmount -= fuelNeeded;
                car.TraveledDistance += distance;
            }
        }
    }
}
