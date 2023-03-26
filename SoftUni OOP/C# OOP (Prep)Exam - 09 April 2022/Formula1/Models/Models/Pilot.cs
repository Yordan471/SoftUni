using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.Models.Models
{
    public class Pilot : IPilot
    {
        private const int LessThen5Symbols = 5;

        private string fullName;
        private IFormulaOneCar car;

        public Pilot(string fullName)
        {
            FullName = fullName;
        }

        public string FullName
        {
            get => fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < LessThen5Symbols)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPilot, value);
                }

                fullName = value;
            }
        }

        public IFormulaOneCar Car
        {
            get => car;
            private set
            {
                if (value == null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCarForPilot);
                }

                car = value;
            }
        }

        public int NumberOfWins { get; private set; }

        public bool CanRace { get; private set; }


        public void AddCar(IFormulaOneCar car)
        {
            //if (car == null)
            //{
            //    throw new NullReferenceException(ExceptionMessages.InvalidCarForPilot);
            //}

            Car = car;
            CanRace = true;
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }

        public override string ToString()
        {
            return $"Pilot {this.FullName} has {this.NumberOfWins} wins.";
        }
    }
}
