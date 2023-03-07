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
            : base(fuelQuantity, fuelConsuption, capacity)
        {
        }

        public override double FuelConsumption
        {
            get => base.FuelConsumption + AddedFuelConsumption;
        }

        public override void Refuel(double amount)
        {
            if (this.Capacity < this.FuelQuantity + amount * 0.95)
            {
                throw new ArgumentException($"Cannot fit {amount} fuel in the tank");             
            }

            FuelQuantity += amount * 0.95;
            //return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
