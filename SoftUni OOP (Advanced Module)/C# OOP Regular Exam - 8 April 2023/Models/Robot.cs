using RobotService.Models.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public abstract class Robot : IRobot
    {
        private const int ZeroCapacity = 0;

        private string model;
        private int batteryCapacity;
        private ICollection<int> interfaceStandards;

        public Robot(string model, int batteryCapacity, int conversionCapacityIndex)
        {
            Model = model;
            BatteryCapacity = batteryCapacity;
            ConvertionCapacityIndex = conversionCapacityIndex;
            BatteryLevel = BatteryCapacity; 

            interfaceStandards = new List<int>();
        }

        public string Model
        {
            get => model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ModelNullOrWhitespace);
                }

                model = value;
            }
                
        }

        public int BatteryCapacity
        {
            get => batteryCapacity;
            private set
            {
                if (batteryCapacity < ZeroCapacity)
                {
                    throw new ArgumentException(ExceptionMessages.BatteryCapacityBelowZero);
                }

                batteryCapacity = value;
            }
        }

        public int BatteryLevel { get; private set; }

        public int ConvertionCapacityIndex { get; private set; }

        public IReadOnlyCollection<int> InterfaceStandards => interfaceStandards as IReadOnlyCollection<int>;

        public void Eating(int minutes)
        {
            BatteryLevel += minutes * ConvertionCapacityIndex;

            if (BatteryLevel > BatteryCapacity)
            {
                BatteryLevel = BatteryCapacity;
            }
        }

        public bool ExecuteService(int consumedEnergy)
        {         
            if (BatteryLevel < consumedEnergy)
            {
                return false;
            }

            BatteryLevel -= consumedEnergy;

            return true;
        }

        public void InstallSupplement(ISupplement supplement)
        {
            this.interfaceStandards.Add(supplement.InterfaceStandard);
            this.BatteryCapacity -= supplement.BatteryUsage;
            this.BatteryLevel -= supplement.BatteryUsage;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name} {this.Model}:");
            sb.AppendLine($"--Maximum battery capacity: {this.BatteryCapacity}");
            sb.AppendLine($"--Current battery level: {this.BatteryLevel}");
            sb.Append($"--Supplements installed: ");

            if (this.InterfaceStandards.Count > 0)
            {
                sb.AppendLine($"{string.Join(" ", interfaceStandards)}");
            }
            else
            {
                sb.AppendLine($"none");
            }
            
            return sb.ToString().TrimEnd();
        }
    }
}
