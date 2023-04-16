using System;
using System.Collections;
using System.Collections.Generic;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
	{
		private ICollection<Character> characters;
		private ICollection<Item> items;

        public string OutputMessages { get; private set; }

        public WarController()
		{
			characters = new List<Character>();
			items = new List<Item>();
		}

		public string JoinParty(string[] args)
		{
			string characterType = args[0];
			string name = args[1];

			Character character = null;

			if (characterType == nameof(Warrior))
			{
				character = new Warrior(name);
			}
			else if (characterType == nameof(Priest))
			{
                character = new Priest(name);
            }
			else
			{
				throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, characterType));
            }

			characters.Add(character);

			return string.Format(SuccessMessages.JoinParty, name);
        }

		public string AddItemToPool(string[] args)
		{
			throw new NotImplementedException();
		}

		public string PickUpItem(string[] args)
		{
			string itemName = args[0];

			Item item = null;

			if (itemName == nameof(HealthPotion))
			{
				item = new HealthPotion();
			}
			else if (itemName == nameof(FirePotion))
			{
				item = new FirePotion();
			}
			else
			{
				throw new ArgumentException(ExceptionMessages.InvalidItem, itemName);
            }

			items.Add(item);

			return string.Format(SuccessMessages.AddItemToPool, itemName);
        }

		public string UseItem(string[] args)
		{
			throw new NotImplementedException();
		}

		public string GetStats()
		{
			throw new NotImplementedException();
		}

		public string Attack(string[] args)
		{
			throw new NotImplementedException();
		}

		public string Heal(string[] args)
		{
			throw new NotImplementedException();
		}
	}
}
