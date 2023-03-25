using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Heroes.Models.Heroes
{
    public abstract class Hero : IHero
    {
        private string name;
        private int health;
        private int armour;
        private IWeapon weapon;

        public Hero(string name, int health, int armour)
        {
            this.Name = name;
            this.Health = health;
            this.Armour = armour;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Hero name cannot be null or empty.");
                }

                name = value;
            }
        }

        public int Health
        {
            get => this.health;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero health cannot be below 0.");
                }

                this.health = value;
            }
        }

        public int Armour
        {
            get => armour;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero armour cannot be below 0.");
                }

                this.armour = value;
            }
        }

        public IWeapon Weapon
        {
            get => weapon;
            private set
            {
                if (weapon == null)
                {
                    throw new ArgumentNullException("Weapon cannot be null.");
                }
            }
        }

        public bool IsAlive
        {
            get => CheckIsAliveStatus();
        }

        private bool CheckIsAliveStatus()
        {
            if (Health > 0)
            {
                return true;
            }

            return false;
        }

        public void AddWeapon(IWeapon weapon)
        {    
            if (weapon == null)
            {
                throw new ArgumentNullException("Weapon cannot be null.");
            }

            this.weapon = weapon;
        }

        public void TakeDamage(int points)
        {
            int armourAfterAttack = this.Armour - points;

            if (armourAfterAttack < 0)
            {
                int healthAfterAttack = this.Health + armourAfterAttack;

                if (healthAfterAttack < 0)
                {
                    this.Health = 0;
                }
                else
                {
                    this.Health += armourAfterAttack;
                }

                this.Armour = 0;
            }
            else
            {
                this.Armour -= points;
            }
        }
    }
}
