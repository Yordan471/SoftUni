using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private readonly List<IMilitaryUnit> army;
        private readonly List<IWeapon> weapons;

        private string name;
        private double budget;

        public Planet(string name, double budget)
        {
            Name = name;
            Budget = budget;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
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

            double totalAmount = army.Sum(a => a.EnduranceLevel) + weapons.Sum(w => w.DestructionLevel);

            if (army.Any(a => a.GetType().Name == nameof(AnonymousImpactUnit)))
            {
                totalAmount *= 1.30;
            }

            if (weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon)))
            {
                totalAmount *= 1.45;
            }

            return Math.Round(totalAmount, 3);
        }

        public IReadOnlyCollection<IMilitaryUnit> Army => this.army;

        public IReadOnlyCollection<IWeapon> Weapons => this.weapons;

        public void AddUnit(IMilitaryUnit unit)
        {
            army.Add(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            weapons.Add(weapon);
        }

        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Planet: {this.Name}");
            sb.AppendLine();
            sb.AppendLine($"--Budget: {this.Budget} billion QUID");
            
            if (army.Count == 0)
            {
                sb.AppendLine($"No units");
            }
            else
            {
                Queue<string> units = new Queue<string>();
               
                foreach (var unit in army)
                {
                    units.Enqueue(unit.GetType().Name);
                }

                sb.Append($"--Forces: {string.Join(", ", units)}");
            }

            sb.AppendLine();

            if (weapons.Count == 0)
            {
                sb.AppendLine($"No weapons");
            }
            else
            {
                Queue<string> weaponsQ = new Queue<string>();

                foreach (var weapon in weaponsQ)
                {
                    weaponsQ.Enqueue(weapon.GetType().Name);
                }

                sb.Append($"--Forces: {string.Join(", ", weaponsQ)}");
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
            army.ForEach(a => a.IncreaseEndurance());
        }
    }
}
