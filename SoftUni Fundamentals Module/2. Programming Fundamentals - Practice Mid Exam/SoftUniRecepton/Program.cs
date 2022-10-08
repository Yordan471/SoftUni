using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniRecepton
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstEmployeeEfficiency = int.Parse(Console.ReadLine());
            int secondEmployeeEfficiency = int.Parse(Console.ReadLine());
            int thirdEmployeeEfficiency = int.Parse(Console.ReadLine());
            int studentCount = int.Parse(Console.ReadLine());

            int studentsGotAnswers = firstEmployeeEfficiency +
                secondEmployeeEfficiency + thirdEmployeeEfficiency;

            int hours = 1;

            if (studentCount == 0)
            {
                hours = 0;
            }

            while (studentsGotAnswers < studentCount)
            {
                if (hours % 4 == 0)
                {
                    hours++;
                    continue;
                }

                studentsGotAnswers += firstEmployeeEfficiency +
                secondEmployeeEfficiency + thirdEmployeeEfficiency;

                hours++;

                if (studentsGotAnswers >= studentCount && hours % 4 == 0)
                {
                    hours++;
                }
            }

            Console.WriteLine($"Time needed: {hours}h.");
        }
    }
}
