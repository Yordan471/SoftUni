using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Abstract_Classes
{
    public abstract class Animal : IAnimal
    {
        //private double AdditionalWeightPerFood = 0;

        public Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
            //FoodEaten = foodEaten;
            //this.AdditionalWeightPerFood = additionalWeightOerFood;
        }

        public string Name { get; private set; }

        public double Weight { get; private set; }

        public int FoodEaten { get; private set; }

        public abstract double WeightModifier { get; }
        
        public abstract IReadOnlyCollection<Type> SpecificFoods { get; }

        public virtual string ProduceSound()
        {
            return $"{this.GetType().Name} - {this.Name}";
        }

        public void EatFood(IFood food)
        {
            if (!SpecificFoods.Any(f => f.Name == food.GetType().Name))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            Weight += food.Quantity * WeightModifier;

            FoodEaten += food.Quantity;
        }

        public override string ToString()
        {
            return $"{GetType().Name} [{this.Name}, ";
        }
    }
}
