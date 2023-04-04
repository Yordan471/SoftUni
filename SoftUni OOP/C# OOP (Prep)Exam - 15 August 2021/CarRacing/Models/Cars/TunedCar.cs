using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars
{
    public class TunedCar : Car
    {
        private const double TunedCarAvailbableFuel = 65;
        private const double TunedCarFuelConsumptionPerRace = 7.5;

        public TunedCar(string make, string model, string vin, int horsePower) : base(make, model, vin, horsePower, TunedCarAvailbableFuel, TunedCarFuelConsumptionPerRace)
        {
        }

        public override void Drive()
        {
            base.Drive();
            this.HorsePower = (int)Math.Floor(this.HorsePower * 0.97);
        }
    }
}
