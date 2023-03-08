using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Abstract_Classes
{
    public abstract class Mammal : IMammal
    {
        public Mammal(string livingRegion)
        {
            LivingRegion = livingRegion;
        }

        public string LivingRegion { get; private set; }
    }
}
