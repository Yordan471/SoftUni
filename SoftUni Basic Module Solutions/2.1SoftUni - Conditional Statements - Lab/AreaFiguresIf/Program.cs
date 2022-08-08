using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaFiguresIf
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string figure = null;
            Console.Write("");
            figure = Console.ReadLine();

            if (figure == "square")
            {                      
                Console.Write("");
                double SqrA = double.Parse(Console.ReadLine());
                Console.WriteLine("{0:F3}",SqrA * SqrA);
            }
            if (figure == "rectangle")
            {
                Console.Write("");
                double RecA = double.Parse(Console.ReadLine());
                Console.Write("");
                double RecB = double.Parse(Console.ReadLine());
                Console.WriteLine("{0:F3}",RecB * RecA);
            }   
            if (figure == "circle")
            {
                Console.Write("");
                double CirA = double.Parse(Console.ReadLine());
                Console.WriteLine("{0:F3}",Math.PI * CirA * CirA);
            }
            if (figure == "triangle")
            {
                Console.Write("");
                double TriA = double.Parse(Console.ReadLine());
                Console.Write("");
                double TriB = double.Parse(Console.ReadLine());
                Console.WriteLine("{0:F3}",TriA * TriB / 2);
            }
        }
    }
}
