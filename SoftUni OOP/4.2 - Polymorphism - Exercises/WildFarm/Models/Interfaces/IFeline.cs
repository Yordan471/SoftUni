using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm.Models.Interfaces
{
    public interface IFeline : IMammal
    {
        public string Breed { get; }
    }
}
