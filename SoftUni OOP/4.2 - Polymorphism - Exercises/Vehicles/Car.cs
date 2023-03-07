using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double AddedFuelConsumption = 0.9;

        public Car(double fuelQuantity, double fuelConsuption) 
            : base(fuelQuantity, fuelConsuption)
        {
        }

        public override double FuelConsumption
        {
            get => base.FuelConsumption + AddedFuelConsumption;
        }

        public override string Drive(int distance)
        {
            if (distance * this.FuelConsumption > this.FuelQuantity)
            {
                return "Car needs refueling";
            }

            this.FuelQuantity -= distance * this.FuelConsumption;
            return $"Car travelled {distance}";
        }

        public override string Refuel(int amount)
        {
            this.FuelQuantity += amount;

            return $"Car: {this.FuelQuantity:f2}";
        }
    }
}
