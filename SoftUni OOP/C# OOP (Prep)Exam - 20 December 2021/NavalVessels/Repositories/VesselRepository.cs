using NavalVessels.Models.Contracts;
using NavalVessels.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Repositories
{
    public class VesselRepository : IRepository<IVessel>
    {
        public IReadOnlyCollection<IVessel> Models => throw new NotImplementedException();

        public void Add(IVessel model)
        {
            throw new NotImplementedException();
        }

        public IVessel FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IVessel model)
        {
            throw new NotImplementedException();
        }
    }
}
