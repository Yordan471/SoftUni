using Gym.Models.Athletes.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Athletes
{
    public abstract class Athlete : IAthlete
    {
        private string fullName;
        private string motivaton;
        private int stamina;
        private int numberOfMedals;

        public Athlete(string fullname, string motivation, int stamina, int numberOfMedals)
        {
            fullName = fullname;
            Motivation = motivation;
            Stamina = stamina;
            NumberOfMedals = numberOfMedals;
        }

        public string FullName
        {
            get => fullName;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteName);
                }

                fullName = value;
            }
        }

        public string Motivation
        {
            get => motivaton;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteMotivation);
                }

                motivaton = value;
            }
        }

        public int Stamina 
        {
            get => stamina; 
            protected set => stamina = value;
        }

        public int NumberOfMedals
        {
            get => numberOfMedals;
            private set
            {
                if(numberOfMedals < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteMedals);
                }

                numberOfMedals = value;
            }
        }

        public abstract void Exercise();       
    }
}
