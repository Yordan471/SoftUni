using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.MilitaryUnits
{
    public abstract class MilitaryUnit : IMilitaryUnit
    {
        private double cost;
        private int enduranceLevel = 1;

        public MilitaryUnit(double cost)
        {
            this.cost = cost;
        }

        public double Cost => cost;
        
        public int EnduranceLevel => this.enduranceLevel;

        public void IncreaseEndurance()
        {
            if (this.enduranceLevel + 1 > 20)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.EnduranceLevelExceeded));
            }

            this.enduranceLevel++;
        }
    }
}
