using NavalVessels.Models.Contracts;
using NavalVessels.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NavalVessels.Repositories
{
    public class VesselRepository : IRepository<IVessel>
    {
        private ICollection<IVessel> vessels;

        public VesselRepository()
        {
            vessels = new List<IVessel>();
        }

        public IReadOnlyCollection<IVessel> Models { get => (IReadOnlyCollection<IVessel>)vessels;}

        public void Add(IVessel model)
        {
            vessels.Add(model);
        }

        public IVessel FindByName(string name)
        {
            IVessel vessel = vessels.FirstOrDefault(v => v.Name == name);

            return vessel;
        }

        public bool Remove(IVessel model)
        {
            return vessels.Remove(model);
        }
    }
}
