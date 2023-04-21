using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Repositories
{
    public class SupplementRepository : IRepository<ISupplement>
    {
        private ICollection<ISupplement> supplements;

        public SupplementRepository ()
        {
            supplements = new List<ISupplement> ();
        }

        public void AddNew(ISupplement model)
        {
            supplements.Add(model);
        }

        public ISupplement FindByStandard(int interfaceStandard)
        {
            ISupplement supplement = supplements.FirstOrDefault(s => s.InterfaceStandard == interfaceStandard);

            return supplement;
        }

        public IReadOnlyCollection<ISupplement> Models()
        {
            return supplements as IReadOnlyCollection<ISupplement>;
        }

        public bool RemoveByName(string typeName)
        {
            ISupplement supplement = supplements.FirstOrDefault(s => s.GetType().Name == typeName);

            return supplements.Remove(supplement);
        }
    }
}
