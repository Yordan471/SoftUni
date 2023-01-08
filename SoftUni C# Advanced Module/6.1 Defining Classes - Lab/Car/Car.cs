using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    public class Car
    {
        public Car(string make, string model, int year)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }

        private string make;
        private string model;
        private int year;

        public string Make
        {
            get { return make; }

            set { make = value; }
        }

        public string Model
        {
            get { return model; }

            set { this.model = value; }
        }

        public int Year
        {
            get { return this.year; }

            set { this.year = value; }
        }
    }
}
