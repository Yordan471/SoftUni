using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Engine_and_Tires
{
    public class Engine
    {
        private int horsePower;
        private double cubicCapacity;

        public Engine(int horsePower, double cubicCapacity)
        {
            HorsePower = horsePower;
            CubicCapacity = cubicCapacity;
        }

        public int HorsePower { get; set; }

        public double CubicCapacity { get; set; }
    }
}
