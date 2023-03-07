using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }
            

        public double Width
        {
            get => width; private set => width = value;
        }

        public double Height
        {
            get => height; private set => height = value;
        }
        

        public override double CalculateArea()
        {
            return this.Width * this.Height;
        }

        public override double CalculatePerimeter()
        {
            return 2 * (this.Width + this.Height);
        }

        public override string Draw()
        {
            return $"{base.Draw()} {this.GetType().Name}";
        }
    }
}
