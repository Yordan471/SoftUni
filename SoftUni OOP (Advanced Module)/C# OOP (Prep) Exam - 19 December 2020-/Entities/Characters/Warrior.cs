﻿using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Warrior : Character, IAttacker
    {
        private const double WarriorBaseHealth = 100;
        private const double WarriorBaseArmor = 50;
        private const double WarriorAbilityPoints = 40;
        private static Satchel bag;       

        public Warrior(string name) : base(name, WarriorBaseHealth, WarriorBaseArmor, WarriorAbilityPoints, bag = new Satchel())
        {           
        }

        public void Attack(Character character)
        {
            this.EnsureAlive();
            
            if (this.Equals(character))
            {
                throw new InvalidOperationException(ExceptionMessages.CharacterAttacksSelf);
            }

            character.TakeDamage(this.AbilityPoints);
        }
    }
}
