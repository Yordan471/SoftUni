using CarRacing.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    public class ProfessionalRacer : Racer
    {
        private const int ProfessionalRacerStartingDrivingExperience = 30;
        private const string ProfessionalRacerRacingBehaviour = "strict";

        public ProfessionalRacer(string username, ICar car) : base(username, ProfessionalRacerRacingBehaviour, ProfessionalRacerStartingDrivingExperience, car)
        {
        }

        public override void Race()
        {
            base.Race();

            if (this.Car.FuelAvailable > 0)
            {
                this.DrivingExperience += 10;
            }       
        }
    }
}
