using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {
        private int destructionLevel;
        private double price;

        public Weapon(int destructionLevel, double price)
        {
            DestructionLevel = destructionLevel;
            Price = price;
        }
        public double Price 
        { 
            get => price; 
            private set => price = value; 
        }

        public int DestructionLevel
        {
            get => destructionLevel;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.TooLowDestructionLevel));
                }
                else if (value > 10)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.TooHighDestructionLevel));
                }

                destructionLevel = value;
            }
        }
    }
}
