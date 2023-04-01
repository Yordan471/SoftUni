using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        public string Name => throw new NotImplementedException();

        public int Capacity => throw new NotImplementedException();

        public double EquipmentWeight => throw new NotImplementedException();

        public ICollection<IEquipment> Equipment => throw new NotImplementedException();

        public ICollection<IAthlete> Athletes => throw new NotImplementedException();

        public void AddAthlete(IAthlete athlete)
        {
            throw new NotImplementedException();
        }

        public void AddEquipment(IEquipment equipment)
        {
            throw new NotImplementedException();
        }

        public void Exercise()
        {
            throw new NotImplementedException();
        }

        public string GymInfo()
        {
            throw new NotImplementedException();
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            throw new NotImplementedException();
        }
    }
}
