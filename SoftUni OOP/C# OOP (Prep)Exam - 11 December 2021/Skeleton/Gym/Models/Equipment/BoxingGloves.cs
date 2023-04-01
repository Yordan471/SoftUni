using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Equipment
{
    public class BoxingGloves : Equipment
    {
        private const double BoxingGlovesWeight = 227;
        private const decimal BoxingGlovesPRICE = 120;

        public BoxingGloves() : base(BoxingGlovesWeight, BoxingGlovesPRICE)
        {
        }
    }
}
