using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Abstract_Classes;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Classes
{
    public class Owl : Animal, IBird
    {
        public Owl(string name, double weight, int foodEaten) 
            : base(name, weight, foodEaten)
        {
        }

        public double WingSize { get; private set; }

        public override string ToString()
        {
            return base.ToString() + "Hoot Hoot";
        }
    }
}
