using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Models
{
    public class Captain : ICaptain
    {
        private string fullName;
        private int combatExperience;
        ICollection<IVessel> vessels;

        public Captain(string fullName)
        {
            FullName = fullName;

            vessels = new List<IVessel>();
        }

        public string FullName
        {
            get => fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(string.Format(ExceptionMessages.InvalidCaptainName));
                }

                fullName = value;
            }
        }

        public int CombatExperience
        {
            get => combatExperience;
            private set => combatExperience = value;
        }

        public ICollection<IVessel> Vessels { get => vessels; private set => vessels = value; }

        public void AddVessel(IVessel vessel)
        {
            if (vessels == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidVesselForCaptain);
            }

            vessels.Add(vessel);
        }

        public void IncreaseCombatExperience()
        {
            CombatExperience += 10;
        }

        public string Report()
        {
            StringBuilder sb = new();

            sb.AppendLine($"{FullName} has {CombatExperience} combat experience and commands {Vessels.Count} vessels.");

            if (Vessels.Count > 0)
            {
                foreach (var vessel in Vessels)
                {
                    sb.AppendLine($"{vessel.ToString()}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
