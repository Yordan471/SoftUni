using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Formula1.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {
        private ICollection<IRace> races;

        public RaceRepository()
        {
            races = new List<IRace>();
        }

        public IReadOnlyCollection<IRace> Models => (IReadOnlyCollection<IRace>)races;

        public void Add(IRace model)
        {
            races.Add(model);
        }

        public IRace FindByName(string name)
        {
            IRace race = races.FirstOrDefault(r => r.RaceName == name);

            if (race == null)
            {
                return null;
            }

            return race;
        }

        public bool Remove(IRace model)
        {
            IRace removeRace = races.FirstOrDefault(r => r.Equals(model));

            if (removeRace != null)
            {
                races.Remove(removeRace);
                return true;
            }

            return false;
        }
    }
}
