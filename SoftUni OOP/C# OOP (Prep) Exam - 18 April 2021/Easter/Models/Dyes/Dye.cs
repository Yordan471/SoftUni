using Easter.Models.Dyes.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Dyes
{
    public class Dye : Contracts.Dye
    {
        private const int UseDecreasePowerBy10 = 10;

        private int power;

        public Dye(int power)
        {
            Power = power;
        }    
        

        public int Power
        {
            get => power;
            private set
            {
                if (value < 0)
                {
                    power = 0;
                }

                power = value;
            }
        }

        public bool IsFinished()
        {
            if (this.Power == 0)
            {
                return true;
            }

            return false;
        }

        public void Use()
        {
            this.Power -= UseDecreasePowerBy10;

            if (this.Power < 0)
            {
                this.Power = 0;
            }
        }
    }
}
