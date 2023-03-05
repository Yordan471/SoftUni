using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MilitaryElite.Models.Enum;
using MilitaryElite.Models.Interfaces;

namespace MilitaryElite
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private Corps corps;
        protected SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, Corps corps) 
            : base(id, firstName, lastName, salary)
        {
            Corps = corps;
        }

        public Corps Corps
        {
            get => corps;
            set
            {
                if (value != Corps.Airforces || value != Corps.Marines)
                {
                    
                }
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()} {Environment.NewLine}Corps: {Corps}";
        }
    }
}
