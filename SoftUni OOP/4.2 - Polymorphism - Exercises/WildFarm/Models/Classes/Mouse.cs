using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Abstract_Classes;
using WildFarm.Models.Foods;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Classes
{
    public class Mouse : Mammal
    {
        private const double MouseWeight = 0.10;

        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override double WeightModifier
        {
            get => MouseWeight;
        }

        public override IReadOnlyCollection<Type> SpecificFoods
        {
            get => new HashSet<Type>() { typeof(Vegetable), typeof(Fruit) };
        }

        public override string ToString()
        {
            return base.ToString() + "Squeak";
        }
    }
}
