using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Abstract_Classes;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Classes
{
    public class Tiger : Animal, IFeline
    {
        public Tiger(string name, double weight, int foodEaten) : base(name, weight, foodEaten)
        {
        }

        public string Breed { get; private set; }

        public string LivingRegion { get; private set; }

        public override string ToString()
        {
            return base.ToString() + "ROAR!!!";
        }
    }
}
