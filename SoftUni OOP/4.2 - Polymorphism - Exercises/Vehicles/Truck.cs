using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double AddedFuelConsumption = 1.6;

        public Truck(double fuelQuantity, double fuelConsuption) 
            : base(fuelQuantity, fuelConsuption)
        {
        }

        public override double FuelConsumption
        {
            get => base.FuelConsumption + AddedFuelConsumption;
        }

        public override void Refuel(double amount)
        {
            this.FuelQuantity += amount * 0.95;

            //return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
