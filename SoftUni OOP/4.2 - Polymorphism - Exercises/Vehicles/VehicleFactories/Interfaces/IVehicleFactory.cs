using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Models.Interfaces;

namespace Vehicles.VehicleFactories.Interfaces
{
    public interface IVehicleFactory
    {
        IVehicle Create(string vehicleType, double fuelQuantity, double fuelConsumption, int capacity);
    }
}
