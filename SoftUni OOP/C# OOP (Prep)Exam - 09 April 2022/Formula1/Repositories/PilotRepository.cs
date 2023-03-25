using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Formula1.Repositories
{
    public class PilotRepository : IRepository<IPilot>
    {
        private readonly ICollection<IPilot> pilots;

        public PilotRepository()
        {
            pilots = new List<IPilot>();
        }

        public IReadOnlyCollection<IPilot> Models => (IReadOnlyCollection<IPilot>)pilots;

        public void Add(IPilot model)
        {
            pilots.Add(model);
        }

        public IPilot FindByName(string name)
        {
            IPilot pilot = pilots.FirstOrDefault(p => p.FullName == name);

            if (pilot == null)
            {
                return null;
            }

            return pilot;
        }

        public bool Remove(IPilot model)
        {
            IPilot removePilot = pilots.FirstOrDefault(p => p.Equals(model));

            if (removePilot != null)
            {
                pilots.Remove(removePilot);
                return true;
            }

            return false;
        }
    }
}
