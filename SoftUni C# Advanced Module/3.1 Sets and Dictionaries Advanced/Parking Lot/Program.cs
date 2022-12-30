using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;

            HashSet<string> set = new HashSet<string>();

            while ((command = Console.ReadLine()) != "END")
            {
                string[] directionCarNumber = command
                    .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                string direction = directionCarNumber[0];
                string carNuber = directionCarNumber[1];

                if (direction == "IN")
                {
                    set.Add(carNuber);
                }
                else
                {
                    set.Remove(carNuber);
                }
            }

            if (set.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, set));
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }         
        }
    }
}
