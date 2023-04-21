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
    public class Hen : Bird
    {
        private const double HenWeight = 0.35;

        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override double WeightModifier
        {
            get => HenWeight;
        }

        public override IReadOnlyCollection<Type> SpecificFoods
        {
            get => new HashSet<Type>() { typeof(Vegetable), typeof(Fruit), typeof(Meat), typeof(Seeds) };
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
