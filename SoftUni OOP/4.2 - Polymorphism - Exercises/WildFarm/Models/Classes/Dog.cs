using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Abstract_Classes;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Classes
{
    public class Dog : Animal, IMammal

    {
        public Dog(string name, double weight, int foodEaten) 
            : base(name, weight, foodEaten)
        {
        }

        public string LivingRegion { get; private set; }
    }
}
