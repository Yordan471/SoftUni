using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsuption) : base(fuelQuantity, fuelConsuption)
        {
        }

        public override string Drive(int distance)
        {
            throw new NotImplementedException();
        }

        public override string Refuel(int amount)
        {
            throw new NotImplementedException();
        }
    }
}
