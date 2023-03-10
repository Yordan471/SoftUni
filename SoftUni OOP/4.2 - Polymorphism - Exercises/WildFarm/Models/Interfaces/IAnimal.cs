using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm.Models.Interfaces
{
    public interface IAnimal
    {
        public string Name { get; }

        public double Weight { get; }

        public int FoodEaten { get; }

        public double WeightModifier { get; }

        public IReadOnlyCollection<Type> SpecificFoods { get; }

        public string ProduceSound();

        public void EatFood(IFood food);
    }
}
