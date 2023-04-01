﻿using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Athletes
{
    public class Boxer : Athlete
    {
        private const int InitialBoxerStamina = 60;

        public Boxer(string fullname, string motivation, int numberOfMedals) : base(fullname, motivation, InitialBoxerStamina, numberOfMedals)
        {
        }

        public override void Exercise()
        {
            this.Stamina += 15;

            if (this.Stamina >= 100)
            {
                this.Stamina = 100;
                throw new ArgumentException(ExceptionMessages.InvalidStamina);
            }
        }
    }
}
