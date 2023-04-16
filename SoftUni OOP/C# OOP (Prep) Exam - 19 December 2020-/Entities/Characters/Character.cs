using System;
using System.Collections.Concurrent;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
		private string name;
		private double baseHealth;
		private double health;
		private double baseArmor;
		private double armor;
		private double abilityPoints;
		private Bag bag;

        public string Name
		{
			get => name;
			private set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }

				name = value;
			}
		}

		public double BaseHealth
		{
			get => baseHealth;
			private set
			{
				baseHealth = value;	
			}
        }

		public double Health
		{
			get => health;
			private set
			{
				if (value > BaseHealth)
				{
					health = BaseHealth;
				}
				else if (value < 0)
			    {
					health = 0;
				}

				health = value;
			}
        }

		public double BaseArmor
		{
			get => baseArmor;
			private set
			{
				

				baseArmor = value;
			}
        }

		public double Armor
		{
			get => armor;
			private set
			{
                if (value < 0)
                {
                    armor = 0;
                }

				armor = value;
            }			
        }

		public double AbilityPoints
		{
			get => abilityPoints;
			private set
			{
                abilityPoints = value;
            }
        }

		public Bag Bag
		{
			get => bag;
			private set => bag = value;
		}

        public bool IsAlive { get; set; } = true;

		protected void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}
	}
}