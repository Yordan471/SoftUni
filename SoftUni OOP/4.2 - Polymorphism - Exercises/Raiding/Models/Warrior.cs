using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Models
{
    public class Warrior : BaseHero
    {
        public Warrior(string name, int power) : base(name, power)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} Hit for {this.Power} damage";
        }
    }
}
