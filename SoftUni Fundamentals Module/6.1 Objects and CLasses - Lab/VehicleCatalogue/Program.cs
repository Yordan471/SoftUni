using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;

namespace VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            Catalogue catalogue = new Catalogue();

            while (true)
            {
                if (command == "end")
                {
                    break;
                }

                List<string> vehicleInformation = command
                    .Split('/')
                    .ToList();

                string vehicle = vehicleInformation[0];

                if (vehicle == "Car")
                {
                    Car car = new Car()
                    {
                        Brand = vehicleInformation[1],
                        Model = vehicleInformation[2],
                        HorsePower = vehicleInformation[3]
                    };

                    catalogue.Cars.Add(car);
                }
                else if (vehicle == "Truck")
                {
                    Truck truck = new Truck()
                    {
                        Brand = vehicleInformation[1],
                        Model = vehicleInformation[2],
                        Weight = vehicleInformation[3]
                    };

                    catalogue.Trucks.Add(truck);
                }

                command = Console.ReadLine();
            }

            if (catalogue.Cars.Count > 0)
            {
                List<Car> orderedCars = catalogue.Cars.OrderBy(car => car.Brand).ToList();
                Console.WriteLine("Cars:");

                foreach (Car car in orderedCars)
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }

            if (catalogue.Trucks.Count > 0)
            {
                List<Truck> orderedTrucks = catalogue.Trucks.OrderBy(truck => truck.Brand).ToList();
                Console.WriteLine("Trucks:");

                foreach (Truck truck in orderedTrucks)
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }
        }
    }
    class Car
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public string HorsePower { get; set; }
    }

    class Truck
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public string Weight { get; set; }
    }

    class Catalogue
    {
        public Catalogue()
        {
            this.Cars = new List<Car>();
            this.Trucks = new List<Truck>(); //интанциране
        }

        public List<Car> Cars { get; set; } // declaration

        public List<Truck> Trucks { get; set; }
    }
}
