using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Bunnies
{
    public class SleepyBunny : Bunny
    {
        private const int InitialEnergy = 50;
        private const int WorkDecreaseEnergy = 10;
        private const int WorkEnergyDecreaseAdditional = 5;

        public SleepyBunny(string name) : base(name, InitialEnergy)
        {
        }

        public override void Work()
        {
            this.Energy -= WorkDecreaseEnergy + WorkEnergyDecreaseAdditional;
        }
    }
}
