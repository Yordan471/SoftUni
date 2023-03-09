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
    public class Dog : Mammal
    {
        private const double DogWeight = 0.40;

        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override double WeightModifier
        {
            get => DogWeight;
        }

        public override IReadOnlyCollection<Type> SpecificFoods
        {
            get => new HashSet<Type>() { typeof(Meat) };
        }

        public override string ToString()
        {
            return base.ToString() + "Woof!";
        }
    }
}
