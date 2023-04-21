using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Athletes
{
    public class Weightlifter : Athlete
    {
        private const int InitialWeightlifterStamina = 50;

        public Weightlifter(string fullname, string motivation, int numberOfMedals) : base(fullname, motivation, InitialWeightlifterStamina, numberOfMedals)
        {
        }

        public override void Exercise()
        {
            this.Stamina += 10;

            if (this.Stamina >= 100)
            {
                this.Stamina = 100;
                throw new ArgumentException(ExceptionMessages.InvalidStamina);
            }
        }
    }
}
