using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private UnitRepository army;
        private WeaponRepository weapons;

        private string name;
        private double budget;

        public Planet(string name, double budget)
        {
            Name = name;
            Budget = budget;

            army = new UnitRepository();
            weapons = new WeaponRepository();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidPlanetName));
                }

                name = value;
            }
        }

        public double Budget
        {
            get => budget;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidBudgetAmount));
                }

                budget = value;
            }
        }

        public double MilitaryPower => TotalAmount();

        private double TotalAmount()
        {

            double totalAmount = army.Models.Sum(a => a.EnduranceLevel) + weapons.Models.Sum(w => w.DestructionLevel);

            if (army.Models.Any(a => a.GetType().Name == nameof(AnonymousImpactUnit)))
            {
                totalAmount *= 1.30;
            }

            if (weapons.Models.Any(w => w.GetType().Name == nameof(NuclearWeapon)))
            {
                totalAmount *= 1.45;
            }

            return Math.Round(totalAmount, 3);
        }

        public IReadOnlyCollection<IMilitaryUnit> Army => this.army.Models;

        public IReadOnlyCollection<IWeapon> Weapons => this.weapons.Models;

        public void AddUnit(IMilitaryUnit unit)
        {
            army.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            weapons.AddItem(weapon);
        }

        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Planet: {this.Name}");
            //sb.AppendLine();
            sb.AppendLine($"--Budget: {this.Budget} billion QUID");
            sb.Append($"--Forces: ");

            if (army.Models.Count == 0)
            {
                sb.AppendLine($"No units");
            }
            else
            {
                Queue<string> units = new Queue<string>();
               
                foreach (var unit in army.Models)
                {
                    units.Enqueue(unit.GetType().Name);
                }

                sb.AppendLine($"{string.Join(", ", units)}");
            }

            sb.Append($"--Combat equipment: ");

            if (weapons.Models.Count == 0)
            {
                sb.AppendLine($"No weapons");
            }
            else
            {
                Queue<string> weaponsQ = new Queue<string>();

                foreach (var weapon in weapons.Models)
                {
                    weaponsQ.Enqueue(weapon.GetType().Name);
                }

                sb.AppendLine($"{string.Join(", ", weaponsQ)}");
            }

            sb.AppendLine($"--Military Power: {this.MilitaryPower}");

            return sb.ToString().Trim();
        }

        public void Profit(double amount)
        {
            budget += amount;
        }

        public void Spend(double amount)
        {
            if (budget < amount)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.UnsufficientBudget));
            }

            budget -= amount;
        }

        public void TrainArmy()
        {
            foreach (var unit in army.Models)
            {
                unit.IncreaseEndurance();
            }
        }
    }
}
