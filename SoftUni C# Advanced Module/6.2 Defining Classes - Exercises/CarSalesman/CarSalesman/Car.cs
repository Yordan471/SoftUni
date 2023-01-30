using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesman
{
    public class Car
    {
        public Car()
        {
            Model = "";
            Engine = null;
            Weight = 0;
            Color = @"n/a";
        }

        public Car(string model, Engine engine) : this()
        {
            Model = model;
            Engine = engine;
        }

        public Car(string model, Engine engine, int weight)
            : this(model, engine)
        {
            Weight = weight;
        }

        public Car(string model, Engine engine, string color)
            : this(model, engine)
        {
            Color = color;
        }

        public Car(string model, Engine engine, int weight, string color)
            : this(model, engine, weight)
        {
            Color = color;
        }


        public string Model { get; set; }

        public Engine Engine { get; set; }

        public int Weight { get; set; }

        public string Color { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($"{this.Model}");
            sb.AppendLine($"  {this.Engine.Model}");
            sb.AppendLine($"    Power: {this.Engine.Power}");

            if (this.Engine.Displacement == 0)
            {
                sb.AppendLine($"    Displacement: n/a");
            }
            else
            {
                sb.AppendLine($"    Displacement: {this.Engine.Displacement}");
            }

            sb.AppendLine($"    Efficiency: {this.Engine.Efficiency}");

            if (this.Weight == 0)
            {
                sb.AppendLine($"  Weight: n/a");
            }
            else
            {
                sb.AppendLine($"  Weight: {this.Weight}");
            }

            sb.AppendLine($"  Color: {this.Color}");
            return sb.ToString().Trim();
        }
    }
}
