using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raw_Data
{
    public class Program
    {
        static void Main(string[] args)
        {
            int numbersOfCars = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < numbersOfCars; i++)
            {
                string[] carsInfo = Console.ReadLine()
                    .Split(' ');

                string model = carsInfo[0];
                string engineSpeed = carsInfo[1];
                int enginePower = int.Parse(carsInfo[2]);
                int cargoWeight = int.Parse(carsInfo[3]);
                string cargoType = carsInfo[4];

                Car car = new Car(model, engineSpeed, enginePower, cargoWeight, cargoType);

                cars.Add(car);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                foreach(Car car in cars)
                {
                    if (car.Cargo.CargoWeight < 1000 && car.Cargo.CargoType == "fragile")
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }
            else if (command == "flamable")
            {
                foreach(Car car in cars)
                {
                    if (car.Engine.EnginePower > 250 && car.Cargo.CargoType == "flamable")
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }
        }
    }

    public class Car
    {
        public Car(string model, string engineSpeed, int enginePower,
            int cargoWeight, string cargoType)
        {
            Model = model;
            Engine = new Engine()
            {
                EngineSpeed = engineSpeed,
                EnginePower = enginePower,
            };

            Cargo = new Cargo()
            {
                CargoWeight = cargoWeight,
                CargoType = cargoType
            };
        }

        public string Model { get; set; }

        public Engine Engine { get; set; }

        public Cargo Cargo { get; set; }
    }

    public class Engine
    {
        public string EngineSpeed { get; set; }

        public int EnginePower { get; set; }
    }

    public class Cargo
    {
        public int CargoWeight { get; set; }

        public string CargoType { get; set; }
    }
}
