using NavalVessels.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Core
{
    public class Controller : IController
    {
        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            throw new NotImplementedException();
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            throw new NotImplementedException();
        }

        public string CaptainReport(string captainFullName)
        {
            throw new NotImplementedException();
        }

        public string HireCaptain(string fullName)
        {
            throw new NotImplementedException();
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            throw new NotImplementedException();
        }

        public string ServiceVessel(string vesselName)
        {
            throw new NotImplementedException();
        }

        public string ToggleSpecialMode(string vesselName)
        {
            throw new NotImplementedException();
        }

        public string VesselReport(string vesselName)
        {
            throw new NotImplementedException();
        }
    }
}
