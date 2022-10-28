using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            //  string command = Console.ReadLine();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                string[] vehicleInformation = command
                    .Split(' ');             
                // по доло проверявъме дали въведения тъп превозно средство е от 
                // тези, които сме предвидили да имаме в програмата.
                // с булевата променлива проверявъме дали типът въведен от потребителя
                // съответства на някой от тези, които имаме.
                // Ако го имаме (true) - out vehicleType - запаметяваме тъпа в променливата
                VehicleType vehicleType;
                bool isVehicleTypeTrue = Enum.TryParse(vehicleInformation[0], true,
                    out vehicleType);

                if (isVehicleTypeTrue)
                {
                    string vehicleModel = vehicleInformation[1];
                    string vehicleColor = vehicleInformation[2];
                    int vehicleHorsepower = int.Parse(vehicleInformation[3]);

                    Vehicle currVehicle = new Vehicle(vehicleType,
                        vehicleModel, vehicleColor, vehicleHorsepower);

                    vehicles.Add(currVehicle);
                }
            }

            while (true)
            {
                string model = Console.ReadLine();

                if (model == "Close the Catalogue")
                {
                    break;
                }
                // намираме първото превозно средство или дефолтно такова, което
                // съутветства на търсеното. По-доло го принтираме.
                var desiredVehicle = vehicles.FirstOrDefault(vehicle => vehicle.Model == model);

                Console.WriteLine(desiredVehicle);
            }
            // тук слагаме в лист всички различни типове от vehicles листа.
            // съутветни всички тип car отиват в лист Cars.
            // всички тип truck отиват в лист trucks.
            List<Vehicle> cars = vehicles.Where(vehicle => vehicle.Type ==
               VehicleType.Car).ToList();
            List<Vehicle> trucks = vehicles.Where(vehicle => vehicle.Type ==
               VehicleType.Truck).ToList();

            //double sumCarsHorsepower = cars.Sum(car => car.Horsepower) / cars.Count * 1.0;
            double avrgCarsHorsepower = cars.Average(car => car.Horsepower);
            Console.WriteLine($"Cars have average horsepower of: {avrgCarsHorsepower:f2}.");

            double avrgTrucksHorsepower = trucks.Average(truck => truck.Horsepower);
            Console.WriteLine($"Trucks have average horsepower of: {avrgTrucksHorsepower:f2}.");
        }
    }

    enum VehicleType
    {
        Car,
        Truck
    }

    class Vehicle
    {
        public Vehicle(VehicleType type, string model, string color, int horsepower)
        {
            Type = type;
            Model = model;
            Color = color;
            Horsepower = horsepower;
        }
        public VehicleType Type { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public int Horsepower { get; set; }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            // appendLine = CW
            stringBuilder.AppendLine($"Type: {Type}");
            stringBuilder.AppendLine($"Model: {Model}");
            stringBuilder.AppendLine($"Color: {Color}");
            stringBuilder.AppendLine($"Horsepower: {Horsepower}");
            // с TrimEnd() премахваме празни пространства, ако има такива.
            return stringBuilder.ToString().TrimEnd();
        }
    }
}


