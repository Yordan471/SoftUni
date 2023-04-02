using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const double BiologistDecreaseOfOxygen = 5;

        public Biologist(string name, double oxygen) : base(name, oxygen)
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
