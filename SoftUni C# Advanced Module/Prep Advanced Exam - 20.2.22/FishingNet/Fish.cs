using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingNet
{
    public class Fish
    {
        private string FishType;
        private double Length;
        private double Weight;

        public Fish(string fishType, double length, double weight)
        {
            this.FishType = fishType;
            this.Length = length;
            this.Weight = weight;
        }

        public override string ToString()
        {
            return $"There is a {this.FishType}, {this.Length} cm. long, and {this.Weight} gr. in weight.";
        }
    }
}
