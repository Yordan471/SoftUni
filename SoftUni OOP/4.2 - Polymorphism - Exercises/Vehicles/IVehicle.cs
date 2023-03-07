using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public interface IVehicle
    {
        public double FuelQuantity { get; }

        public double FuelConsumption { get; }


        public string Drive(double distance);

        public void Refuel(double amount);
    }
}
