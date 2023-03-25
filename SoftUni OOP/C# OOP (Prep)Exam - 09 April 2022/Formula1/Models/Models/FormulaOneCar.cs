using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.Models.Models
{
    public abstract class FormulaOneCar : IFormulaOneCar
    {
        private const int LessThen3Symbols = 3;
        private const int LowerBoundaryHorsepower = 900;
        private const int HigherBoundaryHorsepower = 1050;
        private const double LowerBoundaryEngineDisplacement = 1.6;
        private const double HigherBoundaryEngineDisplacement = 2.0;

        private string model;
        private int horsepower;
        private double engineDisplacement;

        public FormulaOneCar(string model, int horsepower, double engineDisplacement)
        {
            Model = model;
            Horsepower = horsepower;
            EngineDisplacement = engineDisplacement;
        }

        public string Model
        {
            get => model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < LessThen3Symbols)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidF1CarModel, value);
                }

                model = value;
            }
        }

        public int Horsepower
        {
            get => horsepower;
            private set
            {
                if (value < LowerBoundaryHorsepower && value > HigherBoundaryHorsepower)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidF1HorsePower, value.ToString());
                }

                horsepower = value;
            }
        }

        public double EngineDisplacement
        {
            get => engineDisplacement;
            private set
            {
                if (value < LowerBoundaryEngineDisplacement && value > HigherBoundaryEngineDisplacement)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidF1EngineDisplacement, value.ToString());
                }
            }
        }

        public double RaceScoreCalculator(int laps)
        {
            return (EngineDisplacement / Horsepower) * laps;
        }
    }
}
