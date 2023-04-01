using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;
        private int capacity;
        private readonly List<IEquipment> equipments;
        private readonly List<IAthlete> athletes;

        public Gym(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }
                
                name = value;
            }
        }

        public int Capacity { get => capacity; private set => capacity = value; }

        public double EquipmentWeight => equipments.Sum(e => e.Weight);

        public ICollection<IEquipment> Equipment => equipments;

        public ICollection<IAthlete> Athletes => athletes;

        public void AddAthlete(IAthlete athlete)
        {
            if (this.Capacity <= athletes.Count)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }

            athletes.Add(athlete);
        }

        public void AddEquipment(IEquipment equipment)
        {
            equipments.Add(equipment);
        }

        public void Exercise()
        {
            athletes.ForEach(a => a.Exercise());
        }

        public string GymInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Name} is a {this.GetType().Name}:");
            Queue<string> athletesNames = new Queue<string>();

            if (athletes.Count > 0)
            {
                foreach (var athlete in athletes)
                {
                    athletesNames.Enqueue(athlete.FullName);
                }

                sb.AppendLine($"{string.Join(", ", athletesNames)}");
            }
            else
            {
                sb.AppendLine("No athletes");
            }

            sb.AppendLine($"Equipment total count: {equipments.Count}");
            sb.AppendLine($"Equipment total weight: {EquipmentWeight} grams");

            return sb.ToString().Trim();
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            return athletes.Remove(athlete);
        }
    }
}
