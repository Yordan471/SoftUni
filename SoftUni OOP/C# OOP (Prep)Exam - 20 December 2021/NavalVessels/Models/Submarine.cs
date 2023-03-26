using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Models
{
    public class Submarine : Vessel, ISubmarine
    {
        private const double InitialSubmarineArmorThickness = 200;
        private bool submergeMode = false;

        public Submarine(string name, double mainWeaponCalibar, double speed) 
            : base(name, mainWeaponCalibar, speed, InitialSubmarineArmorThickness)
        {
        }

        public bool SubmergeMode { get => submergeMode; private set => submergeMode = value; }

        public void ToggleSubmergeMode()
        {
            if (SubmergeMode == false)
            {
                this.MainWeaponCaliber += 40;
                this.Speed -= 4;
                SubmergeMode = true;
            }
            else if (SubmergeMode == true)
            {
                this.MainWeaponCaliber -= 40;
                this.Speed += 4;
                SubmergeMode = false;
            }
        }

        public override void RepairVessel()
        {
            if (this.ArmorThickness < InitialSubmarineArmorThickness)
            {
                this.ArmorThickness = InitialSubmarineArmorThickness;
            }
        }

        public override string ToString()
        {
            string SubmergeMode = " *Submerge mode: ";

            if (this.SubmergeMode == false)
            {
                SubmergeMode += "OFF";
            }
            else if (this.SubmergeMode == true)
            {
                SubmergeMode += "ON";
            }

            return base.ToString() + Environment.NewLine + SubmergeMode;
        }
    }
}
