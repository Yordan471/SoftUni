using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite
{
    public abstract class SpecialisedSoldier : Soldier ,ISpecialisedSoldier
    {
        public string Airforces { get; set; }

        public string Marines { get; set; }
    }
}
