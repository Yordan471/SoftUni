using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    internal class Car
    {

        public Car(
           string model, int engineSpeed, int enginePower, int cargoWeight,
                   string cargoType, double firstTirePressure, int firstTireAge, double secondTirePressure,
                  int secondTireAge, double thirdTirePressure, int thirdTireAge, double fourthTirePressure,
                   int fourthTireAge)
        {
            Model = model;

            Engine = new Engine { Speed = engineSpeed, Power = enginePower };

            Cargo = new Cargo { Weight = cargoWeight, Type = cargoType };

            Tires = new Tires[4];
            Tires[0] = new Tires { Pressure = firstTirePressure, Age = firstTireAge };
            Tires[1] = new Tires { Pressure = secondTirePressure, Age = secondTireAge };
            Tires[2] = new Tires { Pressure = thirdTirePressure, Age = thirdTireAge };
            Tires[3] = new Tires { Pressure = fourthTirePressure, Age = fourthTireAge };
        }

        public string Model { get; set; }

        public Engine Engine { get; set; }

        public Cargo Cargo { get; set; }

        public Tires[] Tires { get; set; }
    }
}
