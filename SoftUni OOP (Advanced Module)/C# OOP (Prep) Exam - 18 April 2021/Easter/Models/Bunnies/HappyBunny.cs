using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Bunnies
{
    public class HappyBunny : Bunny
    {
        private const int InitialEnergy = 100;
        private const int WorkDecreaseEnergy = 10;

        public HappyBunny(string name) : base(name, InitialEnergy)
        {
        }

        public override void Work()
        {
            this.Energy -= WorkDecreaseEnergy;
        }
    }
}
