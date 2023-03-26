using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Models
{
    public abstract class Vessel : IVessel
    {
        private string name;
        private ICaptain captain;
        private double armorThinkness;
        private double mainWeaponCaliber;
        private double speed;
        private ICollection<string> targets;

        public Vessel(string name, double mainWeaponCalibar, double speed, double armorThickness)
        {
            Name = name;
            MainWeaponCaliber = mainWeaponCalibar;
            Speed = speed;
            this.armorThinkness = armorThickness;
            targets = new List<string>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(string.Format(ExceptionMessages.InvalidVesselName));
                }

                name = value;
            }
        }

        public ICaptain Captain
        {
            get => captain;
            set
            {
                if (captain == null)
                {
                    throw new NullReferenceException(string.Format(ExceptionMessages.InvalidCaptainToVessel));
                }

                captain = value;
            }
        }
        public double ArmorThickness
        {
            get => armorThinkness;
            set => armorThinkness = value;
        }

        public double MainWeaponCaliber
        {
            get => mainWeaponCaliber;
            protected set => mainWeaponCaliber = value;
        }


        public double Speed { get => speed; protected set => speed = value; }

        public ICollection<string> Targets { get => targets; private set => targets = value; }

        public void Attack(IVessel target)
        {
            if (target == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.InvalidTarget));
            }

            double armorLeft = target.ArmorThickness -= this.MainWeaponCaliber;

            if (armorLeft < 0)
            {
                target.ArmorThickness = 0;
            }

            this.targets.Add(target.Name);
        }

        public virtual void RepairVessel()
        {
            
        }

        public virtual string ToStrint()
        {
            StringBuilder sb = new();

            sb.AppendLine($"- {this.Name}");
            sb.AppendLine($"*Type: {this.GetType().Name}");
            sb.AppendLine($"*Armor thickness: {this.ArmorThickness}");
            sb.AppendLine($"*Main weapon caliber: {this.MainWeaponCaliber}");
            sb.AppendLine($"*Speed: {this.Speed} knots");

            if (this.Targets.Count > 0)
            {
                sb.AppendLine($"{string.Join(", ", Targets)}");
            }
            else
            {
                sb.AppendLine($"None");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
