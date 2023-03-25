using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Weapons
{
    public class Weapon : IWeapon
    {
        public string Name => throw new NotImplementedException();

        public int Durability => throw new NotImplementedException();

        public int DoDamage()
        {
            throw new NotImplementedException();
        }
    }
}
