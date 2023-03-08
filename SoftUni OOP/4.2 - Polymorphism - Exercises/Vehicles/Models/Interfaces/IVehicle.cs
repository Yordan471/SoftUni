using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Models.Interfaces
{
    public interface IVehicle
    {
        public int Capacity { get; }

        public double FuelQuantity { get; }

        public double FuelConsumption { get; }


        public string Drive(double distance, bool isAddedConsumption = true);

        public void Refuel(double amount);
    }
}
