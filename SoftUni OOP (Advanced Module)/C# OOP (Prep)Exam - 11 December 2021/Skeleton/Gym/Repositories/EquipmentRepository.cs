using Gym.Models.Equipment.Contracts;
using Gym.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Repositories
{
    public class EquipmentRepository : IRepository<IEquipment>
    {
        private readonly ICollection<IEquipment> equipment;

        public EquipmentRepository()
        {
            equipment = new List<IEquipment>();
        }

        public IReadOnlyCollection<IEquipment> Models => equipment as IReadOnlyCollection<IEquipment>;

        public void Add(IEquipment model)
        {
            equipment.Add(model);
        }

        public IEquipment FindByType(string type)
        {
            IEquipment findEquipment = equipment
               .FirstOrDefault(e => e.GetType().Name == type);
            return findEquipment;
        }

        public bool Remove(IEquipment model)
        {
            return equipment.Remove(model);
        }
    }
}
