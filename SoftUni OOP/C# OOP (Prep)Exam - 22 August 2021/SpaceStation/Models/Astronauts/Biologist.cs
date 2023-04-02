using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const double BiologistDecreaseOfOxygen = 5;
        private const double InitialBiologistOxygen = 70;

        public Biologist(string name) : base(name, InitialBiologistOxygen)
        {
        }

        public override void Breath()
        {
            this.Oxygen -= BiologistDecreaseOfOxygen;

            if (this.Oxygen < 0)
            {
                this.Oxygen = 0;
            }
        }
    }
}
