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

        public abstract string Drive(int distance);


        public abstract string Refuel(int amount);
        
    }
}
