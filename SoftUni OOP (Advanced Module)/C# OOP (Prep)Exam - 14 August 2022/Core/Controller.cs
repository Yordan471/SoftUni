using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Repositories.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private IRepository<IPlanet> planets = new PlanetRepository();

        public Controller()
        {
            planets = new PlanetRepository();
        }

        public string AddUnit(string unitTypeName, string planetName)
        {

            IPlanet planet = this.planets.FindByName(planetName);

            if (planet == default)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (unitTypeName != nameof(AnonymousImpactUnit) &&
                unitTypeName != nameof(SpaceForces) &&
                unitTypeName != nameof(StormTroopers))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }

            if (planet.Army.Any(u => u.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
            }

            IMilitaryUnit unit;

            if (unitTypeName == nameof(SpaceForces))
            {
                unit = new SpaceForces();
            }
            else if (unitTypeName == nameof(StormTroopers))
            {
                unit = new StormTroopers();
            }
            else
            {
                unit = new AnonymousImpactUnit();
            }

            planet.Spend(unit.Cost);
            planet.AddUnit(unit);

            return string.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
            //IPlanet planet = planets.FindByName(planetName);

            //if (planet == null)
            //{
            //    throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            //}


            //if (unitTypeName != nameof(AnonymousImpactUnit) &&
            //    unitTypeName != nameof(SpaceForces) &&
            //    unitTypeName != nameof(StormTroopers))
            //{
            //    throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            //}

            //IMilitaryUnit existingMilitaryUnit = planet.Army.FirstOrDefault(u => u.GetType().Name == unitTypeName);

            //if (existingMilitaryUnit != null)
            //{
            //    throw new InvalidOperationException(string.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
            //}

            //IMilitaryUnit militaryUnit = null;

            //if (unitTypeName == nameof(SpaceForces))
            //{
            //    militaryUnit = new SpaceForces();
            //}
            //else if (unitTypeName == nameof(AnonymousImpactUnit))
            //{
            //    militaryUnit = new AnonymousImpactUnit();
            //}
            //else if (unitTypeName == nameof(StormTroopers))
            //{
            //    militaryUnit = new StormTroopers();
            //}

            //planet.Spend(militaryUnit.Cost);
            //planet.AddUnit(militaryUnit);

            //return string.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            IPlanet planet = planets.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (weaponTypeName != nameof(BioChemicalWeapon) &&
                weaponTypeName != nameof(NuclearWeapon) &&
                weaponTypeName != nameof(SpaceMissiles))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }

            IWeapon existingWeapon = planet.Weapons.FirstOrDefault(u => u.GetType().Name == weaponTypeName);

            if (existingWeapon != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
            }

            IWeapon weapon = null;

            if (weaponTypeName == nameof(BioChemicalWeapon))
            {
                weapon = new BioChemicalWeapon(destructionLevel);
            }
            else if (weaponTypeName == nameof(NuclearWeapon))
            {
                weapon = new NuclearWeapon(destructionLevel);
            }
            else if (weaponTypeName == nameof(SpaceMissiles))
            {
                weapon = new SpaceMissiles(destructionLevel);
            }

            planet.Spend(weapon.Price);
            planet.AddWeapon(weapon);

            return string.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }

        public string CreatePlanet(string name, double budget)
        {
            IPlanet planet = planets.FindByName(name);

            if (planet != null)
            {
                return string.Format(OutputMessages.ExistingPlanet, name);
            }

            planet = new Planet(name, budget);
            planets.AddItem(planet);
            return string.Format(OutputMessages.NewPlanet, name);
        }

        public string ForcesReport()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"***UNIVERSE PLANET MILITARY REPORT***");

            foreach (var planet in planets.Models
                .OrderByDescending(m => m.MilitaryPower)
                .ThenBy(m => m.Name))
            {
                sb.AppendLine(planet.PlanetInfo());
            }

            return sb.ToString().Trim();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet attackingPlanet = planets.FindByName(planetOne);
            IPlanet defendingPlanet = planets.FindByName(planetTwo);

            if (attackingPlanet.MilitaryPower == defendingPlanet.MilitaryPower)
            {
                if (attackingPlanet.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon) &&
                defendingPlanet.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon))) ||
                attackingPlanet.Weapons.Any(w => w.GetType().Name != nameof(NuclearWeapon) &&
                defendingPlanet.Weapons.Any(w => w.GetType().Name != nameof(NuclearWeapon))))
                {
                    attackingPlanet.Spend(attackingPlanet.Budget / 2);
                    defendingPlanet.Spend(defendingPlanet.Budget / 2);
                    return string.Format(OutputMessages.NoWinner);
                }
                else if (attackingPlanet.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon)))
                {
                    return attackingPlanetWins(attackingPlanet, defendingPlanet);
                }
                else if (defendingPlanet.Weapons.Any(w => w.GetType().Name.Equals(nameof(NuclearWeapon))))
                {
                    return defendingPlanetWins(attackingPlanet, defendingPlanet);
                }
            }
            else if (attackingPlanet.MilitaryPower > defendingPlanet.MilitaryPower)
            {
                return attackingPlanetWins(attackingPlanet, defendingPlanet);
            }
            else if (attackingPlanet.MilitaryPower < defendingPlanet.MilitaryPower)
            {
                return defendingPlanetWins(attackingPlanet, defendingPlanet);
            }

            return null;
        }

        private string defendingPlanetWins(IPlanet attackingPlanet, IPlanet defendingPlanet)
        {
            defendingPlanet.Spend(attackingPlanet.Budget / 2);
            defendingPlanet.Profit(defendingPlanet.Budget / 2 +
                attackingPlanet.Army.Sum(u => u.Cost) +
                attackingPlanet.Weapons.Sum(w => w.Price));

            planets.RemoveItem(attackingPlanet.Name);

            return string.Format(OutputMessages.WinnigTheWar, defendingPlanet.Name, attackingPlanet.Name);
        }

        private string attackingPlanetWins(IPlanet attackingPlanet, IPlanet defendingPlanet)
        {
            attackingPlanet.Spend(attackingPlanet.Budget / 2);
            attackingPlanet.Profit(defendingPlanet.Budget / 2 +
                defendingPlanet.Army.Sum(u => u.Cost) +
                defendingPlanet.Weapons.Sum(w => w.Price));

            planets.RemoveItem(defendingPlanet.Name);

            return string.Format(OutputMessages.WinnigTheWar, attackingPlanet.Name, defendingPlanet.Name);
        }

        public string SpecializeForces(string planetName)
        {
            IPlanet planet = planets.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (!planet.Army.Any())
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.NoUnitsFound));
            }     

            double costForTraining = 1.25;
            planet.TrainArmy();
            planet.Spend(costForTraining);

            return string.Format(OutputMessages.ForcesUpgraded, planetName);
        }
    }
}
