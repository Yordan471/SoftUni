using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    public abstract class Racer : IRacer
    {
        private const int DrivingExperienceZero = 0;
        private const int DrivingExperienceOneHundred = 100;

        private string username;
        private string racingBehavior;
        private int drivingExperience;
        private ICar car;

        public Racer(string username, string racingBehaviour, int drivingExperience, ICar car)
        {
            Username = username;
            RacingBehavior = racingBehaviour;
            DrivingExperience = drivingExperience;
            Car = car;
        }

        public string Username
        {
            get => username;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerName);
                }

                username = value;
            }
        }

        public string RacingBehavior
        {
            get => racingBehavior;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerBehavior);
                }

                racingBehavior = value;
            }
        }

        public int DrivingExperience
        {
            get => drivingExperience;
            protected set
            {
                if (value < DrivingExperienceZero && value > DrivingExperienceOneHundred)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerDrivingExperience);
                }

                drivingExperience = value;
            }
        }

        public ICar Car
        {
            get => car;
            private set
            {
                if (car == null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerCar);
                }

                car = value;
            }
        }

        public bool IsAvailable()
        {
            if (this.car.FuelAvailable > 0)
            {
                return true;
            }

            return false;
        }

        public virtual void Race()
        {
            Car.Drive();           
        }
    }
}
