using CarRacing.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    public class StreetRacer : Racer
    {
        private const int StreetRacerDrivingExperience = 10;
        private const string StreetRacerRacingBehaviour = "aggressive";

        public StreetRacer(string username, ICar car) : base(username, StreetRacerRacingBehaviour, StreetRacerDrivingExperience, car)
        {
        }

        public override void Race()
        {
            base.Race();
            this.DrivingExperience += 5;
        }
    }
}
