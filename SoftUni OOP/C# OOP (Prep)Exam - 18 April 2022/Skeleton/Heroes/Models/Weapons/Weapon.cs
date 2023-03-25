using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {
        private string name;
        private int durability;

        public Weapon(string name, int durability)
        {
            this.Name = name;
            this.Durability = durability;
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Weapon type cannot be null or empty.");
                }

                name = value;
            }
        }

        public int Durability
        {
            get => durability;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Durability cannot be below 0.");
                }
            }
        }

        public abstract int DoDamage();
    }
}
