using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeStore
{
    public class Shoe
    {
        public Shoe() { }
        public Shoe(string brand, string type, double size, string material)
        {
            this.Brand = brand;
            this.Type = type;
            this.Size = size;
            this.Material = material;
        }

        public string Brand { get; set; }

        public string Type { get; set; }

        public double Size { get; set; }

        public string Material { get; set; }


        public override string ToString()
        {
            return $"Size {this.Size} {this.Material} {this.Brand} {this.Type} shoe.";
        }
    }
}
