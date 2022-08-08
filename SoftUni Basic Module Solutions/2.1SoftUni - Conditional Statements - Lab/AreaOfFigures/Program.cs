using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaOfFigures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("square");
            Console.WriteLine(" ");
            double SqX = double.Parse(Console.ReadLine());
            double LiceSquare = SqX * SqX;
            Console.WriteLine("{0:F3}", LiceSquare);

            Console.Write("\nrectangle");
            Console.WriteLine("");
            double recA = double.Parse(Console.ReadLine());
            Console.Write("");
            double recB = double.Parse(Console.ReadLine());
            double LiceRec = recA * recB;
            Console.WriteLine("{0:F3}",LiceRec);

            Console.Write("\ncircle");
            Console.WriteLine("");
            double cirA = double.Parse(Console.ReadLine());
            double LiceCir = Math.PI * cirA * cirA;
            Console.WriteLine("{0:F3}",LiceCir);

            Console.Write("\ntriangle");
            Console.WriteLine("");
            double triA = double.Parse(Console.ReadLine());
            Console.Write("");
            double triB = double.Parse(Console.ReadLine());
            double LiceTri = (triA * triB)/2;
            Console.WriteLine("{0:F}",LiceTri);                                                         
        }
    }
}
