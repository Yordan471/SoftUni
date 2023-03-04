using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite
{
    public class LeutenantGeneral : Soldier, ILieutenantGeneral, IPrivate
    {
        public List<Private> Privates { get; set; }

        public decimal Salary()
        {
            
        }
    }
}
