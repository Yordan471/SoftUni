using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories
{
    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private readonly List<IMilitaryUnit> militaryUnits;

        public UnitRepository()
        {
            this.militaryUnits = new List<IMilitaryUnit>();
        }

        public IReadOnlyCollection<IMilitaryUnit> Models => this.militaryUnits;

        public void AddItem(IMilitaryUnit model)
        {
            this.militaryUnits.Add(model);
        }

        public IMilitaryUnit FindByName(string name)
        {
            IMilitaryUnit militaryUnit = this.militaryUnits
                .FirstOrDefault(m => m.GetType().Name.Equals(name));

            if (militaryUnit == null)
            {
                return null;
            }

            return militaryUnit;
        }

        public bool RemoveItem(string name)
        {
            IMilitaryUnit militaryUnit = FindByName(name);

            if (militaryUnit == null)
            {
                return false;
            }

            militaryUnits.Remove(militaryUnit);
            return true;
        }
    }
}
