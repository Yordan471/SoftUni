using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Equipment
{
    public class BoxingGloves : Equipment
    {
        private const double BoxingGlovesWeight = 10000;
        private const decimal BoxingGlovesPRICE = 80;

        public BoxingGloves() : base(BoxingGlovesWeight, BoxingGlovesPRICE)
        {
        }
    }
}
