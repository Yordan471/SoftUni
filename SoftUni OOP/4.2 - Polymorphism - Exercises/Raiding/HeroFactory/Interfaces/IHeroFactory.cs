using Raiding.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.HeroFactory.Interfaces
{
    public interface IHeroFactory
    {
        IBaseHero Create(string name, string heroType);
    }
}
