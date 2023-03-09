using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Abstract_Classes
{
    public abstract class Feline : Animal, IFeline
    {
        protected Feline(string name, double weight, string livingRegion, string breed) : base(name, weight)
        {
            LivingRegion = livingRegion;
            Breed = breed;
        }

        public string Breed { get; private set; }

        public string LivingRegion { get ; private set; }
    }
}
