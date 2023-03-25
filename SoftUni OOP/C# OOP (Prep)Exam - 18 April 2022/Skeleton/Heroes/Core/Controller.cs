using Heroes.Core.Contracts;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Models.Map;
using Heroes.Models.Weapons;
using Heroes.Repositories;
using Heroes.Repositories.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Core
{
    public class Controller : IController
    {
        private IRepository<IHero> heroes;
        private IRepository<IWeapon> weapons;

        public Controller()
        {
            heroes = new HeroRepository();
            weapons = new WeaponRepository();
        }

        public string AddWeaponToHero(string weaponName, string heroName)
        {
            IHero hero = heroes.FindByName(heroName);

            if (hero == null)
            {
                throw new InvalidOperationException($"Hero {heroName} does not exist.");
            }

            IWeapon weapon = weapons.FindByName(weaponName);

            if (weapon == null)
            {
                throw new InvalidOperationException($"Weapon {weaponName} does not exist.");
            }

            if (hero.Weapon != null)
            {
                throw new InvalidOperationException($"Hero {heroName} is well-armed.");
            }

            hero.AddWeapon(weapon);
            weapons.Remove(weapon);

            return $"Hero {heroName} can participate in battle using a {weapon.GetType().Name.ToLower()}.";
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            if (heroes.FindByName(name) != null)
            {
                throw new InvalidOperationException("Invalid hero type.");
            }

            IHero hero = null;
            bool isKnight = false;

            if (type == nameof(Knight))
            {
                hero = new Knight(name, health, armour);
                isKnight = true;
            }
            else if (type == nameof(Barbarian))
            {
                hero = new Barbarian(name, health, armour);
            }
            else
            {
                throw new InvalidOperationException("Invalid hero type.");
            }

            heroes.Add(hero);

            if (isKnight)
            {
                return $"Successfully added Sir {name} to the collection.";
            }
            else
            {
                return $"Successfully added Barbarian {name} to the collection.";
            }
        }

        public string CreateWeapon(string type, string name, int durability)
        {
            if (weapons.FindByName(name) != null)
            {
                throw new InvalidOperationException($"The weapon {name} already exists.");
            }

            IWeapon weapon = null;
            
            if (type == nameof(Claymore))
            {
                weapon = new Claymore(name, durability);
            }
            else if (type == nameof(Mace))
            {
                weapon = new Mace(name, durability);
            }
            else
            {
                throw new InvalidOperationException("Invalid weapon type.");
            }

            weapons.Add(weapon);

            return $"A {type.ToLower()} {name} is added to the collection.";
        }

        public string HeroReport()
        {
            throw new NotImplementedException();
        }

        public string StartBattle()
        {
            IMap map = new Map();

            ICollection<IHero> players = (ICollection<IHero>)heroes.Models;

            return map.Fight(players);
        }
    }
}
