using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalTitles
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("");
            double age = double.Parse(Console.ReadLine());

            Console.Write("");
            string gender = Console.ReadLine();

            if (gender == "f")
            {
                if (age >= 16)
                {
                    Console.WriteLine("Ms.");
                }
                else
                {
                    Console.WriteLine("Miss");
                }
            }
            else
            {
                if(age >= 16)
                {
                    Console.WriteLine("Mr.");
                }
                else
                {
                    Console.WriteLine("Master");
                }
            }
        }
    }
}
