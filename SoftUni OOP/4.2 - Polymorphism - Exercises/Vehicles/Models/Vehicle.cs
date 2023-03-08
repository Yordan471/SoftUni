using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Models.Interfaces;

namespace Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private int capacity;
        private double additionalFuelConsumption;

        protected Vehicle(double fuelQuantity, double fuelConsuption, int capacity, double additionalFuelConsuption)
        {
            Capacity = capacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsuption;
            this.additionalFuelConsumption = additionalFuelConsuption;
        }

        public double FuelQuantity
        {
            get => fuelQuantity;
            private set    
            {
                if (capacity < value)
                {
                    fuelQuantity = 0;
                }
                else
                {
                    fuelQuantity = value;
                }
            }
        }

        public virtual double FuelConsumption
        {
            get => fuelConsumption; set => fuelConsumption = value;
        }

        public int Capacity
        {
            get => capacity;
            private set => capacity = value;
        }

        public virtual string Drive(double distance, bool isAddedConsumption = true)
        {
            double consumption = 0;

            if (isAddedConsumption)
            {
                consumption += additionalFuelConsumption;
            }

            consumption += FuelConsumption;

            if (distance * consumption > FuelQuantity)
            {
                throw new ArgumentException($"{GetType().Name} needs refueling");
                //return $"{GetType().Name} needs refueling";
            }

            FuelQuantity -= distance * consumption;
            return $"{GetType().Name} travelled {distance} km";
        }


        public virtual void Refuel(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException($"Fuel must be a positive number");
            }
            else if (this.Capacity < this.FuelQuantity + amount)
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
