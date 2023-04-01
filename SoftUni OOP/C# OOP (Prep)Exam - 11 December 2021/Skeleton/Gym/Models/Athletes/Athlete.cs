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

        public string FullName
        {
            get => fullName;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteName);
                }

                fullName = value;
            }
        }


        public string Motivation => throw new NotImplementedException();

        public int Stamina => throw new NotImplementedException();

        public int NumberOfMedals => throw new NotImplementedException();

        public void Exercise()
        {
            throw new NotImplementedException();
        }
    }
}
