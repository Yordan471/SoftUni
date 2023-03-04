using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite
{
    public class Engineer : SpecialisedSoldier, IPrivate, IEngineer
    {
        public Dictionary<string, int> JobNameAndHours { get; set; }

        public decimal Salary()
        {
            throw new NotImplementedException();
        }
    }
}
