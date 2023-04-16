using System;
using System.Collections.Concurrent;
using WarCroft.Constants;
using WarCroft.Entities.Inventory;
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

		public Character(string name, double health, double armor, double abilityPoints, Bag bag)
		{
			Name = name;
			Health = health;
			BaseHealth = health;
			Armor = armor;
			BaseArmor = armor;
			AbilityPoints = abilityPoints;
			Bag = bag;
		}

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
		    set
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

		public void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}

		public void TakeDamage(double hitPoints)
		{
			this.EnsureAlive();

		    if (this.Armor - hitPoints < 0)
		    {
		    	this.Health += this.Armor - hitPoints;
		    
		    	if (this.Health <= 0)
		    	{
		    		this.Health = 0;
		    		this.IsAlive = false;
		    	}
		    
		    	this.Armor = 0;
		    }
		    else
			{
                this.Armor -= hitPoints;
            }		    			
		}

		public void UseItem(Item item)
		{			
	     	item.AffectCharacter(this);			
		}
    }
}