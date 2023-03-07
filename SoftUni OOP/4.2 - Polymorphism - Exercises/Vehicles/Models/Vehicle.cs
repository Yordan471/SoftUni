using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Models.Interfaces;

namespace Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        private double fuelConsuption;
        private int capacity;

        protected Vehicle(double fuelQuantity, double fuelConsuption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsuption;
        }

        public double FuelQuantity
        {
            get => fuelQuantity; set => fuelQuantity = value;
        }

        public virtual double FuelConsumption
        {
            get => fuelConsuption; private set => fuelConsuption = value;
        }

        public int Capacity
        {
            get => capacity; private set => capacity = value;
        }

        public virtual string Drive(double distance)
        {
            if (distance * FuelConsumption > FuelQuantity)
            {
                return $"{GetType().Name} needs refueling";
            }

            FuelQuantity -= distance * FuelConsumption;
            return $"{GetType().Name} travelled {distance} km";
        }


        public virtual void Refuel(double amount)
        {
            if (this.Capacity < this.FuelQuantity + amount)
            {
                throw new ArgumentException($"Cannot fit {amount} fuel in the tank");
            }

            FuelQuantity += amount;
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {FuelQuantity:f2}".ToString();
        }
    }
}
