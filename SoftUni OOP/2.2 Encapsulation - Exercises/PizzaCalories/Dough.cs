using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public class Dough 
    {
        private Dictionary<string, double> flourTypeAndModifier;
        private Dictionary<string, double> bakingtechniqueAndModifier;
        private const int minGrams = 1;
        private const int maxGrams = 200;
        private const int baseCaloriesPerGram = 2;

        private string flourType;
        private string bakingTechnique;
        private double grams;

        
        public Dough(string flourType, string bakingTechnique, double grams)
        {
            flourTypeAndModifier = new Dictionary<string, double> { { "white", 1.5 }, { "wholegrain", 1.0 } };
            bakingtechniqueAndModifier = new Dictionary<string, double> { { "crispy", 0.9 }, { "chewy", 1.1 }, { "homemade", 1.0 } };

            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Grams = grams;
        }


        public string FlourType
        {
            get => flourType;
            set
            {
                if (!flourTypeAndModifier.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                flourType = value;
            }
        }

        public string BakingTechnique
        {
            get => bakingTechnique;
            set
            {
                if (!bakingtechniqueAndModifier.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                bakingTechnique = value;
            }
        }

        public double Grams
        {
            get => grams;
            set
            {
                if (value < minGrams || value > maxGrams)
                {
                    throw new ArgumentException($"Dough weight should be in the range [{minGrams}..{maxGrams}].");
                }

                grams = value;
            }
        }

        public double CaloriesPerGram { get => baseCaloriesPerGram; }

        public double CalculateDroughCalories()
        {
            double calories = CaloriesPerGram * flourTypeAndModifier[flourType.ToLower()] * bakingtechniqueAndModifier[bakingTechnique.ToLower()] * grams;
            return CaloriesPerGram * flourTypeAndModifier[flourType.ToLower()] * bakingtechniqueAndModifier[bakingTechnique.ToLower()] * grams;
        }
    }
}
