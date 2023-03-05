using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MilitaryElite.Models.Enum;
using MilitaryElite.Models.Interfaces;

namespace MilitaryElite
{
    public class Engineer : SpecialisedSoldier
    {
        public Engineer(string id, string firstName, string lastName, decimal salary, Corps corps, IReadOnlyCollection<Repair> repairs) 
            : base(id, firstName, lastName, salary, corps)
        {
            Repairs = repairs;
        }

        public IReadOnlyCollection<Repair> Repairs { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new();

            sb.AppendLine($"{base.ToString()}");
            
            if (Repairs.Any())
            {
                foreach (var pair in Repairs)
                {
                    sb.AppendLine($"  {pair.ToString()}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
