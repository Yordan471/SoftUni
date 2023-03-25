using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private ICollection<IWeapon> weapons;

        public IReadOnlyCollection<IWeapon> Models => (IReadOnlyCollection<IWeapon>)weapons;

        public void Add(IWeapon model)
        {
            weapons.Add(model);
        }

        public IWeapon FindByName(string name)
        {
            IWeapon findWeapon = weapons.FirstOrDefault(w => w.Name == name);

            if (findWeapon != null)
            {
                return findWeapon;
            }

            return null;
        }

        public bool Remove(IWeapon model)
        {
            IWeapon weaponToRemove = weapons.FirstOrDefault(w => w.Equals(model));

            if (weaponToRemove != null)
            {
                weapons.Remove(weaponToRemove);
                return true;
            }

            return false;
        }
    }
}
