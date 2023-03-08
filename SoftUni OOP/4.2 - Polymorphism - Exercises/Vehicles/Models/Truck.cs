using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double AddedFuelConsumption = 1.6;

        public Truck(double fuelQuantity, double fuelConsuption, int capacity)
            : base(fuelQuantity, fuelConsuption, capacity, AddedFuelConsumption)
        {
        }

        public override void Refuel(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException($"Fuel must be a positive number");
            }
            else if (this.Capacity < this.FuelQuantity + amount)
            {
                throw new ArgumentException($"Cannot fit {amount} fuel in the tank");             
            }

            base.Refuel(amount * 0.95);
            //return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
