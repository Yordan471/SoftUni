using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drones
{
    public class Drone
    {
        public Drone(string name, string brand, int range)
        {
            Name = name;
            Brand = brand;
            Range = range;
            Available = true;
        }

        public string Name { get; set; }

        public string Brand { get; set; }

        public int Range { get; set; }

        public bool Available { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Drone: {this.Name}");
            sb.AppendLine($"Manufactured by: {this.Brand}");
            sb.AppendLine($"Range: {this.Range} kilometers");

            return sb.ToString().Trim();
        }
    }
}
