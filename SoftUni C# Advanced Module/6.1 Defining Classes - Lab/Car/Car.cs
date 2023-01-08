using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    class Vehicle
    {
        public Vehicle (string make, string model, int year)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }

        private string make;
        private string model;
        private int year;

        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }
    }
}
