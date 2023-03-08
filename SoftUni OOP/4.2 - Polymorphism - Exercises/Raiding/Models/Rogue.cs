using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Models
{
    public class Rogue : BaseHero
    {
        private const int RoguePower = 80;

        public Rogue(string name, int power) : base(name, RoguePower)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} Hit for {this.Power} damage";
        }
    }
}
