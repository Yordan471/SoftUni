using System;
using System.Collections.Generic;
using System.Linq;
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
        

        public virtual string ProduceSound()
        {
            return $"{this.GetType().Name} - ";
        }

        public void WeightGain()
        {

        }
    }
}
