using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Models
{
    public class Battleship : Vessel, IBattleship
    {
        private const double InitialBattleshipArmorThickness = 300;

        public Battleship(string name, double mainWeaponCalibar, double speed) 
            : base(name, mainWeaponCalibar, speed, InitialBattleshipArmorThickness)
        {
        }

        public bool SonarMode { get; private set; }

        public void ToggleSonarMode()
        {
            if (SonarMode == false)
            {
                this.MainWeaponCaliber += 40;
                this.Speed -= 5;
            }
            else if (SonarMode == true)
            {
                this.MainWeaponCaliber -= 40;
                this.Speed += 5;
            }
        }

        public override void RepairVessel()
        {
            if (this.ArmorThickness < InitialBattleshipArmorThickness)
            {
                this.ArmorThickness = InitialBattleshipArmorThickness;
            }
        }

        public override string ToString()
        {
            string sonarMode = string.Empty;

            if (this.SonarMode == false)
            {
                sonarMode = "OFF";
            }
            else if (this.SonarMode == true)
            {
                sonarMode = "ON";
            }

            return base.ToString() + Environment.NewLine + sonarMode;
        }
    }
}
