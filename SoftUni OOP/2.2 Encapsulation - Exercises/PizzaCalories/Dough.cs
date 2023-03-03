using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public class Dough : Flour
    {
        private string flourType;
        private string bakingTechnique;
        private double grams;
        private int caloriesPerGram = 2;

        public Dough(string flourType, string bakingTechnique, double grams)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Grams = grams;
        }


        public string FlourType
        {
            get => flourType;
            set
            {
                if (value != White && value != Wholegrain)
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
                if (value != Crispy && value != Chewy && value != Homemade)
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
                if (value < MinGrams || value > MaxGrams)
                {
                    throw new ArgumentException($"Dough weight should be in the range [{MinGrams}..{MaxGrams}].");
                }

                grams = value;
            }
        }

        public string CalculateDoughCalories()
        {
            double doughtTypeModifier = 0;
            double backingTechniqueModifier = 0;


            switch (this.FlourType)
            {
                case "White":
                    doughtTypeModifier = 1.5;
                    break;
                case "Wholegrain":
                    doughtTypeModifier = 1.0;
                    break;
            }

            switch(this.BakingTechnique)
            {
                case "Crispy":
                    backingTechniqueModifier = 0.9;
                    break;
                case "Chewy":
                    backingTechniqueModifier = 1.1;
                    break;
                case "Homemade":
                    backingTechniqueModifier = 1.0;
                    break;
            }

            double doughCalories = caloriesPerGram * Grams * doughtTypeModifier * backingTechniqueModifier;

            return $"{doughCalories:f2}".ToString();
        }
    }
}
