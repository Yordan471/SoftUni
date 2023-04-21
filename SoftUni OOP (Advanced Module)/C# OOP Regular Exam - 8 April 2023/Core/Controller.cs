using RobotService.Core.Contracts;
using RobotService.Models;
using RobotService.Models.Contracts;
using RobotService.Repositories;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private RobotRepository robots;
        private SupplementRepository supplements;

        public Controller()
        {
            this.robots = new RobotRepository();
            this.supplements = new SupplementRepository();
        }

        public string CreateRobot(string model, string typeName)
        {
            IRobot robot = null;

            if (typeName == nameof(DomesticAssistant))
            {
                robot = new DomesticAssistant(model);
            }
            else if (typeName == nameof(IndustrialAssistant))
            {
                robot = new IndustrialAssistant(model);
            }
            else
            {
                return string.Format(OutputMessages.RobotCannotBeCreated, typeName);
            }

            robots.AddNew(robot);

            return string.Format(OutputMessages.RobotCreatedSuccessfully, typeName, model);
        }

        public string CreateSupplement(string typeName)
        {
            ISupplement supplement = null;

            if (typeName == nameof(SpecializedArm))
            {
                supplement = new SpecializedArm();
            }
            else if (typeName == nameof(LaserRadar))
            {
                supplement = new LaserRadar();
            }
            else
            {
                return string.Format(OutputMessages.SupplementCannotBeCreated, typeName);
            }

            supplements.AddNew(supplement);

            return string.Format(OutputMessages.SupplementCreatedSuccessfully, typeName);
        }

        public string PerformService(string serviceName, int intefaceStandard, int totalPowerNeeded)
        {
            ICollection<IRobot> takeRobots = robots
                .Models()
                .Where(r => r.InterfaceStandards.Contains(intefaceStandard))
                .ToList();

            if (takeRobots.Count == 0)
            {
                return string.Format(OutputMessages.UnableToPerform, intefaceStandard);
            }

            takeRobots = takeRobots.OrderByDescending(r => r.BatteryLevel).ToList();
            int sumOfAllBatteryLevels = takeRobots.Sum(r => r.BatteryLevel);

            if (sumOfAllBatteryLevels < totalPowerNeeded)
            {
                return string.Format(OutputMessages.MorePowerNeeded, serviceName, totalPowerNeeded - sumOfAllBatteryLevels);
            }

            int usedRobots = 0;

            while (totalPowerNeeded > 0)
            {
                foreach (var robot in takeRobots.Where(r => r.BatteryLevel > 0))
                {
                    if (robot.BatteryLevel >= totalPowerNeeded)
                    {
                        robot.ExecuteService(totalPowerNeeded);
                        totalPowerNeeded = 0;
                        usedRobots++;
                        break;
                    }
                    else
                    {
                        totalPowerNeeded -= robot.BatteryLevel;
                        robot.ExecuteService(robot.BatteryLevel);
                        usedRobots++;
                    }
                }
            }

            return string.Format(OutputMessages.PerformedSuccessfully, serviceName, usedRobots);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var robot in robots.Models()
                .OrderByDescending(r => r.BatteryLevel)
                .ThenBy(r => r.BatteryCapacity))
            {
                sb.AppendLine($"{robot.ToString()}");
            }

            return sb.ToString().TrimEnd();              
        }

        public string RobotRecovery(string model, int minutes)
        {
            ICollection<IRobot> robotsToFeed = robots.Models().Where(r => r.Model == model).ToList();
            int countFedRobots = 0;

            foreach (IRobot robot in robotsToFeed.Where(r => r.BatteryLevel / r.BatteryCapacity < 0.5))
            {
                robot.Eating(minutes);
                countFedRobots++;
            }

            return string.Format(OutputMessages.RobotsFed, countFedRobots);
        }

        public string UpgradeRobot(string model, string supplementTypeName)
        {
            ISupplement supplement = supplements.Models().FirstOrDefault(s => s.GetType().Name == supplementTypeName);
            int interfaceValue = supplement.InterfaceStandard;

            ICollection<IRobot> takenRobots = robots.Models()
                .Where(r => r.Model == model && !r.InterfaceStandards.Contains(interfaceValue))
                //.Where(r => !r.InterfaceStandards.Contains(interfaceValue))
                .ToList();

            if (takenRobots.Count == 0)
            {
                return string.Format(OutputMessages.AllModelsUpgraded, supplementTypeName);
            }

            takenRobots.First().InstallSupplement(supplement);
            supplements.RemoveByName(supplementTypeName);

            return string.Format(OutputMessages.UpgradeSuccessful, model, supplementTypeName);
        }
    }
}
