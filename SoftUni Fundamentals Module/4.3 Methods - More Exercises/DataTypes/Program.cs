using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
 
            ReturnByType(type);
        }

        static void ReturnByType(string type)
        {
            switch (type)
            {
                case "int":
                    ReturnInteger(type);
                    break;
                case "real":
                    ReturnDouble(type);
                    break;
                case "string":
                    ReturnString(type);
                    break;
            }
        }

        static void ReturnInteger(string type)
        {
            int input = int.Parse(Console.ReadLine());
            Console.WriteLine(input * 2);
        }

        static void ReturnDouble(string type)
        {
            double input = double.Parse(Console.ReadLine());
            double result = input * 1.5;
            Console.WriteLine($"{result:f2}");
        }

        static void ReturnString(string type)
        {
            string input = Console.ReadLine();
            Console.WriteLine($"${input}$");
        }
    }
}
