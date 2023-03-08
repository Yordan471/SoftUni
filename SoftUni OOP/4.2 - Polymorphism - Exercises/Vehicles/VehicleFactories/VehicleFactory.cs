using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Models;
using Vehicles.Models.Interfaces;
using Vehicles.VehicleFactories.Interfaces;

namespace Vehicles.VehicleFactories
{
    public class VehicleFactory : IVehicleFactory
    {
        public IVehicle Create(string vehicleType, double fuelQuantity, double fuelConsumption, int capacity)
        {
            switch (vehicleType)
            {
                case "Car":
                    return new Car(fuelQuantity, fuelConsumption, capacity);
                case "Truck":
                    return new Truck(fuelQuantity, fuelConsumption, capacity);
                case "Bus":
                    return new Bus(fuelQuantity, fuelConsumption, capacity);
                default:
                    throw new ArgumentException("Invalid vehicle type");
            }
        }
    }
}
