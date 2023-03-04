using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite
{
    public class Commando : SpecialisedSoldier, IPrivate, ICommando
    {
        public Dictionary<string, string> MissionCodeNameAndState { get; set; }

        public decimal Salary()
        {
            throw new NotImplementedException();
        }
    }
}
