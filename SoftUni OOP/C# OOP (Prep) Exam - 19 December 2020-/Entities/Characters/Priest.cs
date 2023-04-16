using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Priest : Character, IHealer
    {
        public Priest(string name, double health, double armor, double abilityPoints, Bag bag) : base(name, health, armor, abilityPoints, bag)
        {
        }

        public void Heal(Character character)
        {
            throw new NotImplementedException();
        }
    }
}
