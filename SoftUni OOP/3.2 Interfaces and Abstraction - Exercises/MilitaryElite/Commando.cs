using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MilitaryElite.Models.Enum;
using MilitaryElite.Models.Interfaces;

namespace MilitaryElite
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(string id, 
            string firstName, 
            string lastName, 
            decimal salary, 
            Corps corps, 
            IReadOnlyCollection<Mission> missions)
            : base(id, firstName, lastName, salary, corps)
        {
            Missions = missions;
        }

        public IReadOnlyCollection<IMission> Missions { get; private set; }

        //IReadOnlyCollection<IMission> ICommando.Missions => throw new NotImplementedException();

        public override string ToString()
        {
            StringBuilder sb = new();

            sb.AppendLine($"{base.ToString()}{Environment.NewLine}Missions:");

            if (Missions.Any())
            {
                foreach (var mission in Missions)
                {
                    sb.AppendLine($"  {mission.ToString()}");
                }              
            }

            return sb.ToString().TrimEnd();
        }
    }
}
