using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MilitaryElite.Models.Interfaces;

namespace MilitaryElite
{
    public class LeutenantGeneral : Private, ILieutenantGeneral
    {
        //private ICollection<Private> privates;

        public LeutenantGeneral(string id, string firstName, string lastName, decimal salary, IReadOnlyCollection<Private> privates) 
            : base(id, firstName, lastName, salary)
        {
           Privates = privates;
        }

        public IReadOnlyCollection<Private> Privates { get; private set; }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{base.ToString()}");
            sb.AppendLine($"Privates:");
            
            if (Privates.Count > 0)
            {
                foreach (Private p in Privates)
                {
                    sb.AppendLine($"{  p.ToString()}");
                }
            }

            return sb.ToString().Trim();
        }
    }
}
