using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Models.Interfaces;

namespace Vehicles.Models
{
    public class Bus : Vehicle
    {
        private const double AdditionalFuelCons = 1.4;

        public Bus(double fuelQuantity, double fuelConsuption, int capacity) 
            : base(fuelQuantity, fuelConsuption, capacity, AdditionalFuelCons)
        {
        }
    }
}
