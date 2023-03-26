using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Models
{
    public class Battleship : Vessel
    {
        private const double InitialBattleshipArmorThickness = 300;

        public Battleship(string name, double mainWeaponCalibar, double speed) 
            : base(name, mainWeaponCalibar, speed, InitialBattleshipArmorThickness)
        {
        }
    }
}
