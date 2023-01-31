using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUni_Parking
{
    public class CarDriver
    {
        CarDriver(string name, string license)
        {
            this.Name = name;
            this.License = license;
        }


        public string Name { get; set; }

        public string License { get; set; }
    }
}
