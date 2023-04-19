using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Repositories
{
    public class RobotRepository : IRepository<IRobot>
    {
        private ICollection<IRobot> robots;

        public RobotRepository()
        {
            robots = new List<IRobot>();
        }

        public void AddNew(IRobot model)
        {
            robots.Add(model);
        }

        public IRobot FindByStandard(int interfaceStandard)
        {
            return robots.FirstOrDefault(r => r.InterfaceStandards.Contains(interfaceStandard));
        }

        public IReadOnlyCollection<IRobot> Models()
        {
            return robots as IReadOnlyCollection<IRobot>;
        }

        public bool RemoveByName(string typeName)
        {
            IRobot robot = robots.FirstOrDefault(r => r.Model == typeName);

            return robots.Remove(robot);
        }
    }
}
