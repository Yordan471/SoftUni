using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        private double fuelConsuption;

        protected Vehicle(double fuelQuantity, double fuelConsuption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsuption;
        }

        public double FuelQuantity
        {
            get => fuelQuantity ; set => fuelQuantity = value;
        }

        public virtual double FuelConsumption
        {
            get => fuelConsuption; private set => fuelConsuption = value;
        }

        public virtual string Drive(double distance)
        {
            if (distance * this.FuelConsumption > this.FuelQuantity)
            {
                return $"{this.GetType().Name} needs refueling";
            }

            this.FuelQuantity -= distance * this.FuelConsumption;
            return $"{this.GetType().Name} travelled {distance} km";
        }


        public virtual void Refuel(double amount)
        {
            this.FuelQuantity += amount;           
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}".ToString();
        }
    }
}
