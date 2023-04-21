using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Abstract_Classes
{
    public abstract class Bird : Animal, IBird
    {
        protected Bird(string name, double weight, double wingSize) : base(name, weight)
        {
            WingSize = wingSize;
        }

        public double WingSize { get; }

        public override string ToString()
        {
            return $"{base.ToString()}{this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}
