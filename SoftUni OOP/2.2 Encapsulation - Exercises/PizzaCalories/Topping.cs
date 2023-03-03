using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public class Topping
    {
        private Dictionary<string, double> toppingAndModifier;
        private const int baseCaloriesPerGram = 2;
        private const double minGrams = 1;
        private const double maxGrams = 50;

        private double weight;
        private string toppingType;

        public Topping(string toppingType, double weight)
        {
            toppingAndModifier = new Dictionary<string, double> { { "meat", 1.2 }, { "veggies", 0.8 }, { "cheese", 1.1 }, { "sauce", 0.9 } };

            this.ToppingType = toppingType;
            this.Weight = weight;
        }

        public string ToppingType
        {
            get => toppingType;
            set
            {
                if (!toppingAndModifier.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                toppingType = value;
            }
        }

        public double Weight
        {
            get => weight;
            set
            {
                if (value <  minGrams || value > maxGrams)
                {
                    throw new ArgumentException($"{ToppingType} weight should be in the range [{minGrams}..{maxGrams}].");
                }

                weight = value;
            }
        }

        public double CalculateCaloriesToppin()
        {
            double calories = baseCaloriesPerGram * weight * toppingAndModifier[toppingType.ToLower()];
            return baseCaloriesPerGram * weight * toppingAndModifier[toppingType.ToLower()];            
        }
    }
}
