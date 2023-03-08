using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Abstract_Classes
{
    public abstract class Animal : IAnimal
    {
        public Animal(string name, double weight, int foodEaten)
        {
            Name = name;
            Weight = weight;
            FoodEaten = foodEaten;
        }

        public string Name { get; private set; }

        public double Weight { get; private set; }

        public int FoodEaten { get; private set; }
    }
}
