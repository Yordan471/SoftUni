using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Abstract_Classes
{
    public abstract class Feline : IFeline
    {
        public Feline(string breed)
        {
            Breed = breed;
        }

        public string Breed { get; private set; }

        public string LivingRegion { get ; private set; }
    }
}
